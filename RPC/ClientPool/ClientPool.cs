using Thrift;
using Thrift.Transport;
using Thrift.Protocol;
using Thrift.Transport.Client;
namespace CUGOJ.CUGOJ_Tools.RPC.ClientPool;

public class ClientPool<T> : IClientPool<T> where T : TBaseClient, IDisposable
{
    public T? Client
    {
        get
        {
            if (_host != string.Empty && _constructor != null)
            {
                try
                {
                    TTransport transport = new TSocketTransport(_host, _port, new TConfiguration(), 1000);
                    TProtocol protocol = new TBinaryProtocol(transport);
                    var client = _constructor.Invoke(new object[] { protocol }) as T;
                    transport.OpenAsync();
                    return client;
                }
                catch (Exception e)
                {
                    Log.Logger.Warn("未能连接到RPC服务器,Exception={0}", e.Message);
                }
            }
            return null;
        }
    }
    public ClientPool()
    {
        var clientType = typeof(T);
        _constructor = clientType.GetConstructor(new[] { typeof(TProtocol) });
        if (_constructor == null)
            Log.Logger.Error("无法创建客户端,请检查客户端类型");
    }
    private System.Reflection.ConstructorInfo? _constructor;
    private string _host = string.Empty;
    private int _port = 0;
    public void Setup(string host, int port)
    {
        _host = host;
        _port = port;
    }
}