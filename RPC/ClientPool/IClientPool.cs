using Thrift;
namespace CUGOJ.CUGOJ_Tools.RPC.ClientPool;
public interface IClientPool<T> where T : TBaseClient, IDisposable
{
    public T? Client { get; }
    public void Setup(string host, int port);
}