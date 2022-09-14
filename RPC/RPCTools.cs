using System.Diagnostics;
using CUGOJ.RPC.Gen.Base;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;
using Thrift.Transport.Client;
using CUGOJ.RPC.Gen.Services;

namespace CUGOJ.CUGOJ_Tools.RPC;

public static class RPCTools
{
    public enum RPCStatus
    {
        OK = 0,
        Error = 1
    }

    public static BaseResp SuccessBaseResp()
    {
        return new BaseResp(((int)RPCStatus.OK));
    }

    public static BaseResp ErrorBaseResp(Exception? e = null)
    {
        BaseResp resp = new BaseResp(((int)RPCStatus.Error));
        resp.Extra = new Dictionary<string, string>();
        if (e != null)
        {
            resp.Extra.Add("ErrorMsg", e.Message);
        }
        else
        {
            resp.Extra.Add("ErrorMsg", "远程调用出错");
        }
        return resp;
    }

    public static Base NewBase()
    {
        var res = new Base();
        res.Extra = new();
        var activity = System.Diagnostics.Activity.Current;
        if (activity != null)
        {
            res.Extra["TraceContext"] = activity.Id;
            res.Extra["ServiceID"] = Context.Context.ServiceBaseInfo.ServiceID;
            res.Extra["UserID"] = Context.Context.UserID;
        }
        return res;
    }

    public static Base NewRootBase()
    {
        var res = new Base();
        res.Extra = new();
        using var activity = new Activity(RPCService.ServiceName);
        activity.Start();
        if (activity != null)
        {
            res.Extra["TraceContext"] = activity.Id;
            res.Extra["ServiceID"] = Context.Context.ServiceBaseInfo.ServiceID;
            res.Extra["UserID"] = Context.Context.UserID;
        }
        activity?.Stop();
        return res;
    }

    public static async Task<T> CreateClient<T>(string host, int port) where T : TBaseClient
    {
        TTransport transport = new TSocketTransport(host, port, new TConfiguration(), 1000);
        TProtocol protocol = new TBinaryProtocol(transport);
        var clientType = typeof(T);
        var constructor = clientType.GetConstructor(new[] { typeof(TProtocol) });
        if (constructor == null)
            throw new Exception("无法创建客户端,请检查客户端类型");
        var client = constructor.Invoke(new object[] { protocol }) as T;
        if (client == null)
            throw new Exception("无法创建客户端,请检查客户端类型");
        await transport.OpenAsync();
        return client;
    }
    public static ServiceTypeEnum GetServiceTypeEnumByClientType<T>() where T : TBaseClient
    {
        Type type = typeof(T);
        if (type == typeof(CUGOJ.RPC.Gen.Services.Base.BaseService.Client))
        {
            return ServiceTypeEnum.Base;
        }
        if (type == typeof(CUGOJ.RPC.Gen.Services.Core.CoreService.Client))
        {
            return ServiceTypeEnum.Core;
        }
        if (type == typeof(CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.Client))
        {
            return ServiceTypeEnum.Authentication;
        }
        else
        {
            throw new Exception("未知的服务类型");
        }
    }

    public static async Task<PingResponse> ExecPing<T>(T client) where T : TBaseClient
    {
        var startTime = Tools.CommonTools.UnixMili();
        var req = new PingRequest(startTime);
        req.Base = NewRootBase();
        PingResponse? resp;
        if (client is CUGOJ.RPC.Gen.Services.Base.BaseService.Client)
        {
            var _client = client as CUGOJ.RPC.Gen.Services.Base.BaseService.Client;
            if (_client == null)
            {
                throw new Exception("Base服务异常");
            }
            resp = await _client.Ping(req);
        }
        else if (client is CUGOJ.RPC.Gen.Services.Core.CoreService.Client)
        {
            var _client = client as CUGOJ.RPC.Gen.Services.Core.CoreService.Client;
            if (_client == null)
            {
                throw new Exception("Core服务异常");
            }
            resp = await _client.Ping(req);
        }
        else if (client is CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.Client)
        {
            var _client = client as CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.Client;
            if (_client == null)
            {
                throw new Exception("Authentication服务异常");
            }
            resp = await _client.Ping(req);
        }
        else
        {
            throw new Exception("未知的服务类型");
        }
        resp.Timestamp = resp.Timestamp - startTime;
        return resp;
    }

}