using Thrift;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Protocol;
using CUGOJ.RPC.Gen.Base;
using CUGOJ.CUGOJ_Tools.RPC.ClientPool;
using CUGOJ.RPC.Gen.Services;
using CUGOJ.CUGOJ_Tools.RPC.LoadBalance;
namespace CUGOJ.CUGOJ_Tools.RPC;

public static class RPCClientManager
{
    private static IClientPool<CUGOJ.RPC.Gen.Services.Core.CoreService.Client> _clientPool = new ClientPool<CUGOJ.RPC.Gen.Services.Core.CoreService.Client>();

    public static async Task<CUGOJ.RPC.Gen.Services.Core.CoreService.Client?> GetCenter()
    {
        if (_clientPool == null)
        {
            return null;
        }
        return await _clientPool.GetClient();
    }

    private static void ConnectCenter(string host, int port)
    {
        // Center = null;
        _clientPool.Setup(host, port);
        // if (RPCService.IsCenter && !RPCService.Ready)
        // {
        //     Task.Run(() =>
        //     {
        //         while (!RPCService.Ready)
        //         {
        //             Thread.Sleep(100);
        //         }
        //         TTransport transport = new TSocketTransport(host, port, new TConfiguration(), 1000);
        //         TProtocol protocol = new TBinaryProtocol(transport);
        //         Center = new CUGOJ.RPC.Gen.Services.Core.CoreService.Client(protocol);
        //         transport.OpenAsync();
        //     });
        //     return;
        // }
        // TTransport transport = new TSocketTransport(host, port, new TConfiguration(), 1000);
        // TProtocol protocol = new TBinaryProtocol(transport);
        // Center = new CUGOJ.RPC.Gen.Services.Core.CoreService.Client(protocol);
        // transport.OpenAsync();
    }
    private static object _initLock = new object();
    private static int _initCount = 0;
    public static void Init(string host, int port)
    {
        if (_initCount != 0) return;
        lock (_initLock)
        {
            if (_initCount != 0) return;
            _initCount++;
            ConnectCenter(host, port);
            CUGOJ.CUGOJ_Tools.CronJob.CronJob.AddJob(PingCenter, 0, 5);
            _authenticationService = CUGOJ.CUGOJ_Tools.Trace.TraceFactory.CreateTracableObject<MinPathBalancer<CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.Client>>(false, false);
            _coreService = CUGOJ.CUGOJ_Tools.Trace.TraceFactory.CreateTracableObject<MinPathBalancer<CUGOJ.RPC.Gen.Services.Core.CoreService.Client>>(false, false);
            _baseService = CUGOJ.CUGOJ_Tools.Trace.TraceFactory.CreateTracableObject<MinPathBalancer<CUGOJ.RPC.Gen.Services.Base.BaseService.Client>>(false, false);

        }
    }
    private static ILoadBalancer<CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.Client>? _authenticationService;
    private static ILoadBalancer<CUGOJ.RPC.Gen.Services.Core.CoreService.Client>? _coreService;
    private static ILoadBalancer<CUGOJ.RPC.Gen.Services.Base.BaseService.Client>? _baseService;

    public static CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.Client? AuthenticationClient
    { get; set; }

    private static int _port;
    private static string _connectionString = string.Empty;
    private static bool _lostCenter = false;
    private static SemaphoreSlim _pingCenterLock = new SemaphoreSlim(1, 1);
    private static async Task PingCenter()
    {
        if (!RPCService.Ready) return;
        using var center = await GetCenter();
        if (center == null) return;
        if (_pingCenterLock.CurrentCount == 0) return;
        await _pingCenterLock.WaitAsync();
        try
        {
            if (_lostCenter)
            {
                if (!RPCService.IsCenter)
                    await RegisterService(_port, _connectionString);
                _lostCenter = false;
            }
            else
            {
                var startTime = Tools.CommonTools.UnixMili();
                var req = new CUGOJ.RPC.Gen.Base.PingRequest(startTime);
                req.Base = RPCTools.NewRootBase();
                var resp = await center.Ping(req);
                if (resp == null || resp.BaseResp.Status != ((int)RPCTools.RPCStatus.OK))
                {
                    throw new Exception("Center服务异常");
                }
                else
                {
                    Log.Logger.Info("Center服务正常,ping:{0}", resp.Timestamp - startTime);
                }
            }
        }
        catch (Exception e)
        {
            _lostCenter = true;
            Log.Logger.Warn("Center服务异常,正在重连,Exception:{0}", e.Message);
        }
        finally
        {
            _pingCenterLock.Release();
        }
    }
    public static async Task<CUGOJ.RPC.Gen.Services.Core.RegisterServiceResponse> RegisterService(int port, string connectionString)
    {
        using var client = await GetCenter();
        if (client == null)
            throw new Exception("Center服务未连接");
        _port = port;
        _connectionString = connectionString;
        var registerReq = new CUGOJ.RPC.Gen.Services.Core.RegisterServiceRequest(connectionString, port);
        registerReq.Base = RPCTools.NewRootBase();
        return await client.RegisterService(registerReq);
    }

}