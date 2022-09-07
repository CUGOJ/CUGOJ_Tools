using CUGOJ.CUGOJ_Tools.Trace;
namespace CUGOJ.CUGOJ_Tools.RPC;

public static partial class RPCService
{
    public static async Task StartCoreService<T>(string env, string? ip = null, int? port = null, string? traceAddress = null, string? logAddress = null, string? mysqlAddress = null, string? redisAddress = null, string? neo4jAddress = null, Action? preStart = null) where T : class, CUGOJ.RPC.Gen.Services.Core.CoreService.IAsync
    {
        Console.WriteLine("正在启动Core服务");
        if (ip == null)
            ip = await GetInternetIP();
        if (port == null)
            port = GetLegalPort();
        if (port == null || port == ERR_PORT)
        {
            throw new Exception("未找到18000到18999之间的空闲端口,服务未能正常启动");
        }
        IsCenter = true;
        Context.Context.ServiceBaseInfo = new CUGOJ.RPC.Gen.Base.ServiceBaseInfo()
        {
            ServiceID = System.Guid.NewGuid().ToString(),
            ServiceIP = ip,
            ServicePort = port.ToString(),
            ServiceType = CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Core,
            RegisterTime = Tools.CommonTools.Unix(),
            Env = env,
            TraceAddress = traceAddress,
            LogAddress = logAddress,
            MysqlAddress = mysqlAddress,
            RedisAddress = redisAddress,
            Neo4jAddress = neo4jAddress
        };
        var handler = Trace.TraceFactory.CreateTracableObject<T>(new ServiceInterceptor());
        CUGOJ.RPC.Gen.Services.Core.CoreService.AsyncProcessor processor = new(handler);
        await StartService(CoreServiceName, processor, null, port.Value, preStart);
    }
}
