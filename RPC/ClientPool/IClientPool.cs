using Thrift;
namespace CUGOJ.CUGOJ_Tools.RPC.ClientPool;
public interface IClientPool<T> where T : TBaseClient, IDisposable
{
    public Task<T?> GetClient();
    public void Setup(string host, int port);
}