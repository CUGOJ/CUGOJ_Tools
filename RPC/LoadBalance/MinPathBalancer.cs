using Thrift;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Protocol;
using CUGOJ.CUGOJ_Tools.RPC.ClientPool;
using CUGOJ.RPC.Gen.Base;
namespace CUGOJ.CUGOJ_Tools.RPC.LoadBalance;

public class MinPathBalancer<T> : ILoadBalancer<T> where T : TBaseClient, IDisposable
{
    private class PingResponseStruct
    {
        public PingResponse PingResponse;
        public IClientPool<T> ClientPool;
        public PingResponseStruct(PingResponse pingResponse, IClientPool<T> clientPool)
        {
            PingResponse = pingResponse;
            ClientPool = clientPool;
        }
    }
    private List<IClientPool<T>> _clientPools = new List<IClientPool<T>>();
    private List<ServiceBaseInfo> _serviceInfos = new List<ServiceBaseInfo>();
    private IClientPool<T>? _curPool = null;
    public T? Client
    {
        get
        {
            if (_curPool == null) return null;
            return _curPool.Client;
        }
    }
    private ServiceTypeEnum _serviceType = RPCTools.GetServiceTypeEnumByClientType<T>();
    private System.Threading.SemaphoreSlim _updateLock = new SemaphoreSlim(1, 1);
    public virtual async void UpdateServiceInfo()
    {
        if (!RPCService.Ready) return;
        if (_updateLock.CurrentCount == 0) return;
        await _updateLock.WaitAsync();

        try
        {
            using var client = RPCClientManager.Center;
            if (client == null)
                throw new Exception("Center服务未连接");
            var req = new CUGOJ.RPC.Gen.Services.Core.DiscoverServiceRequest(_serviceType);
            req.Base = RPCTools.NewBase();
            var resp = await client.DiscoverService(req);
            if (resp.BaseResp == null || resp.BaseResp.Status != ((int)RPCTools.RPCStatus.OK))
                throw new Exception("服务发现失败");
            List<IClientPool<T>> newClientPools = new List<IClientPool<T>>();
            List<ServiceBaseInfo> newServiceInfos = new List<ServiceBaseInfo>();
            foreach (var newClientInfo in resp.Services)
            {
                bool found = false;
                for (int i = 0; i < _serviceInfos.Count; i++)
                {
                    if (_serviceInfos[i].ServiceID == newClientInfo.ServiceID)
                    {
                        newClientPools.Add(_clientPools[i]);
                        newServiceInfos.Add(newClientInfo);
                        found = true;
                        break;
                    }
                }
                if (found) continue;
                var newClient = new ClientPool<T>();
                newClient.Setup(newClientInfo.ServiceIP, int.Parse(newClientInfo.ServicePort));
                if (newClient == null)
                    continue;
                newClientPools.Add(newClient);
                newServiceInfos.Add(newClientInfo);
            }
            lock (_pingLock)
            {
                _clientPools = newClientPools;
                _serviceInfos = newServiceInfos;
                if (_clientPools.Count == 0)
                    _curPool = null;
                else if (_clientPools.Find(x => x == _curPool) == null)
                    _curPool = _clientPools[0];
            }
        }
        catch (Exception e)
        {
            CUGOJ.CUGOJ_Tools.Log.Logger.Warn("更新服务信息失败,Exception={0}", e.Message);
        }
        finally
        {
            _updateLock.Release();
        }
    }
    private System.Threading.SemaphoreSlim _pingLock = new System.Threading.SemaphoreSlim(1, 1);
    public virtual async void Ping()
    {
        if (!RPCService.Ready) return;
        if (_pingLock.CurrentCount == 0) return;
        await _pingLock.WaitAsync();
        try
        {
            List<PingResponseStruct> pingResponseStructs = new List<PingResponseStruct>();
            for (int i = 0; i < _clientPools.Count; i++)
            {
                var serviceInfo = _serviceInfos[i];
                try
                {
                    using var client = _clientPools[i].Client;
                    if (client == null)
                        throw new Exception("未能获取连接");
                    var resp = await RPCTools.ExecPing(client);
                    if (resp.BaseResp == null || resp.BaseResp.Status != ((int)RPCTools.RPCStatus.OK))
                    {
                        throw new Exception();
                    }
                    Log.Logger.Info("{type}正常联通,ServiceID={0},ServiceIP={1},ServicePort={2},Ping={3}", serviceInfo.ServiceType, serviceInfo.ServiceID, serviceInfo.ServiceIP, serviceInfo.ServicePort, resp.Timestamp);
                    pingResponseStructs.Add(new PingResponseStruct(resp, _clientPools[i]));
                }
                catch (Exception e)
                {
                    CUGOJ.CUGOJ_Tools.Log.Logger.Warn("{type}服务失联,serviceInfo={0},exception={1}", serviceInfo.ServiceType, serviceInfo, e.Message);
                }
            }
            pingResponseStructs.Sort((a, b) => a.PingResponse.Timestamp.CompareTo(b.PingResponse.Timestamp));
            if (pingResponseStructs.Count != 0)
            {
                _curPool = pingResponseStructs[0].ClientPool;
            }
            else
            {
                _curPool = null;
            }
        }
        catch (Exception e)
        {
            CUGOJ.CUGOJ_Tools.Log.Logger.Warn("Ping服务失败,Exception={0}", e);
        }
        finally
        {
            _pingLock.Release();
        }
    }
    public MinPathBalancer()
    {
        CronJob.CronJob.AddJob(UpdateServiceInfo, 0, 5);
        CronJob.CronJob.AddJob(Ping, 0, 1);
    }
}