using Thrift;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Protocol;
using CUGOJ.RPC.Gen.Base;
namespace CUGOJ.CUGOJ_Tools.RPC;

public static class RPCClient
{
    internal static List<ServiceBaseInfo>? GetServiceBaseInfoList(ServiceTypeEnum type)
    {
        var resp = CoreClient.Client?.DiscoverService(new CUGOJ.RPC.Gen.Services.Core.DiscoverServiceRequest(type)).Result;
        if (resp != null && resp.BaseResp.Status == ((int)RPCTools.RPCStatus.OK))
        {
            return resp.Services;
        }
        return null;
    }
    internal static ServiceBaseInfo? GetServiceBaseInfo(ServiceTypeEnum type)
    {
        var resp = CoreClient.Client?.DiscoverService(new CUGOJ.RPC.Gen.Services.Core.DiscoverServiceRequest(type)).Result;
        if (resp != null && resp.BaseResp.Status == ((int)RPCTools.RPCStatus.OK) && resp.Services.Count != 0)
        {
            return resp.Services[0];
        }
        return null;
    }
    public static class CoreClient
    {
        static CoreClient()
        {
            System.Threading.Timer timer = new Timer((state) =>
            {

            });
        }

        private static CUGOJ.RPC.Gen.Services.Core.CoreService.Client? _client;
        public static CUGOJ.RPC.Gen.Services.Core.CoreService.Client? Client
        {
            get
            {
                if (_client == null)
                {
                    throw new Exception("Core服务异常");
                }
                return _client;
            }
        }

        internal static void Init(string host, int port)
        {
            TTransport transport = new TSocketTransport(host, port, new TConfiguration(), 1000);
            TProtocol protocol = new TBinaryProtocol(transport);
            _client = new CUGOJ.RPC.Gen.Services.Core.CoreService.Client(protocol);
            transport.OpenAsync();
        }

    }

    public static class AuthenticationClient
    {
        private static Object _lockObject = new Object();
        private static DateTime _lockTime = new DateTime();
        private static CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.Client? _client;
        public static CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.Client Client
        {
            get
            {
                if (_client == null)
                {
                    if (_lockTime <= DateTime.Now)
                    {
                        lock (_lockObject)
                        {
                            if (_lockTime <= DateTime.Now)
                            {
                                _lockTime = DateTime.Now.AddSeconds(5);
                                var info = GetServiceBaseInfo(ServiceTypeEnum.Authentication);
                                if (info != null)
                                {
                                    Init(info.ServiceIP, Convert.ToInt32(info.ServicePort));
                                }
                            }
                        }
                    }
                }
                if (_client == null)
                {
                    throw new Exception("Authentication服务异常");
                }
                return _client;
            }
        }
        internal static void Init(string host, int port)
        {
            TTransport transport = new TSocketTransport(host, port, new TConfiguration(), 1000);
            TProtocol protocol = new TBinaryProtocol(transport);
            _client = new CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.Client(protocol);
            transport.OpenAsync();
        }
    }
}