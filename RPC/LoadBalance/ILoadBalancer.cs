using Thrift;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Protocol;
using CUGOJ.RPC.Gen.Base;
namespace CUGOJ.CUGOJ_Tools.RPC.LoadBalance;
public interface ILoadBalancer<T> where T : TBaseClient
{
    public Task<T?> GetClient();
}