using System.Net.Mime;
using Thrift;
using Thrift.Server;
using Thrift.Processor;
using CUGOJ.CUGOJ_Tools.Trace;
using OpenTelemetry;
using OpenTelemetry.Resources;
using System.Diagnostics;
using System.Net;
using OpenTelemetry.Trace;

namespace CUGOJ.CUGOJ_Tools.RPC;
public static partial class RPCService
{
    public static bool Ready { get; private set; } = false;
    public static bool IsCenter { get; private set; } = false;
    public static CUGOJ.RPC.Gen.Base.ServiceTypeEnum ServiceType { get; private set; } = CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Authentication;
    public static readonly int MIN_PORT = 18000;
    public static readonly int MAX_PORT = 18999;
    public static readonly int ERR_PORT = 0;
    public static readonly int NULL_PORT = 0;

    private static readonly Dictionary<CUGOJ.RPC.Gen.Base.ServiceTypeEnum, string> _serviceName = new()
    {
        {CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Authentication,"CUGOJ.Authentication"},
        {CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Base,"CUGOJ.Base"},
        {CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Core,"CUGOJ.Core"},
        {CUGOJ.RPC.Gen.Base.ServiceTypeEnum.File,"CUGOJ.File"},
        {CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Gateway,"CUGOJ.Gateway"},
        {CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Judger,"CUGOJ.Judger"},
        {CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Sandbox,"CUGOJ.Sandbox"},
    };
    public static string ServiceName
    {
        get
        {
            if (_serviceName.ContainsKey(ServiceType))
            {
                return _serviceName[ServiceType];
            }
            else
            {
                return "CUGOJ.Unknown";
            }
        }
    }

    private static async Task<string> GetInternetIP()
    {
        HttpClient httpClient = new();
        var resp = await httpClient.GetAsync("http://ip.42.pl/raw");
        if (resp == null)
        {
            throw new Exception("获取本机公网IP地址失败");
        }
        var ip = await resp.Content.ReadAsStringAsync();
        if (ip == null)
        {
            throw new Exception("获取本机公网IP地址失败");
        }
        return ip;
    }
    public static void RegisterService(ITAsyncProcessor processor, string registerKey)
    {

    }
    private static int GetLegalPort()
    {
        var properties = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();
        HashSet<int> usedIp = new HashSet<int>();
        foreach (var endPoint in properties.GetActiveTcpListeners())
            usedIp.Add(endPoint.Port);
        foreach (var endPoint in properties.GetActiveUdpListeners())
            usedIp.Add(endPoint.Port);
        foreach (var connection in properties.GetActiveTcpConnections())
            usedIp.Add(connection.LocalEndPoint.Port);
        for (int port = MIN_PORT; port <= MAX_PORT; port++)
        {
            if (!usedIp.Contains(port))
            {
                return port;
            }
        }
        return ERR_PORT;
    }
    private static TracerProvider InitTraceProvider(string serviceName, string endPoint)
    {
        return Sdk.CreateTracerProviderBuilder()
        .AddSource(serviceName)
        .SetResourceBuilder(
            ResourceBuilder.CreateDefault().AddService(serviceName)
        )
        .AddJaegerExporter(opt =>
        {
            opt.Endpoint = new Uri(endPoint);
            opt.Protocol = OpenTelemetry.Exporter.JaegerExportProtocol.HttpBinaryThrift;
        })
        .Build();
    }


    public static async Task<CUGOJ.RPC.Gen.Base.ServiceBaseInfo> ConnectCore(string connectionString, int port)
    {
        var registerInfo = RPCRegisterInfo.NewRPCRegisterInfoByConnectionString(connectionString);
        RPCClientManager.Init(registerInfo.CoreIP, registerInfo.CorePort);
        if (RPCClientManager.Center == null)
        {
            throw new Exception("未能成功建立与Core服务的联系,请检查连接串的正确性");
        }
        try
        {
            var registerResp = await RPCClientManager.RegisterService(port, connectionString);
            if (registerResp == null)
            {
                throw new Exception("未能成功建立与Core服务的联系,请检查连接串的正确性");
            }
            var serviceBaseInfo = registerResp.ServiceBaseInfo;
            if (serviceBaseInfo == null)
            {
                throw new Exception("未能获取正确的服务信息,请检查连接串的正确性");
            }
            return serviceBaseInfo;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception("未能成功建立与Core服务的联系,请检查连接串的正确性");
        }
    }

    private static async Task InitServices(string? connectionString, int port)
    {
        if (!Tools.DBTools.InitSqlite<Dao.RPCContext>())
            throw new Exception("初始化数据库失败");
        var serviceName = ServiceName;
        Console.WriteLine("正在初始化服务:" + serviceName);
        CUGOJ.CUGOJ_Tools.CronJob.CronJob.Init();
        Context.Context.ServiceName = serviceName;
        if (Context.Context.Debug)
        {
            if (Context.Context.ServiceBaseInfo == null)
                Context.Context.ServiceBaseInfo = new();
            Context.Context.ServiceBaseInfo.ServiceID = Guid.NewGuid().ToString();
            Context.Context.ServiceBaseInfo.ServiceIP = "127.0.0.1";
            Context.Context.ServiceBaseInfo.ServicePort = port.ToString();
            Context.Context.ServiceBaseInfo.Env = "debug";
        }
        else if (!IsCenter)
        {
            using var activity = new Activity(ServiceName);
            activity.Start();
            try
            {
                var storedConnectionString = Dao.RPCDao.GetConnectionString();
                if (storedConnectionString != null) connectionString = storedConnectionString;
                if (connectionString == null)
                {
                    throw new Exception("非Core服务首次启动必须传入ConnectionString参数");
                }
                var serviceBaseInfo = await ConnectCore(connectionString, port);
                Context.Context.ServiceBaseInfo = serviceBaseInfo;
                Console.WriteLine("成功连接到Core服务");
                Console.WriteLine("服务信息:\n" + System.Text.Json.JsonSerializer.Serialize<CUGOJ.RPC.Gen.Base.ServiceBaseInfo>(serviceBaseInfo));
                Dao.RPCDao.SaveConnectionString(connectionString);
                activity.Stop();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        else
        {
            RPCClientManager.Init(Context.Context.ServiceBaseInfo.ServiceIP, port);
        }
        Interceptor.InitIntercepor(new(ServiceName));
        if (!CUGOJ.CUGOJ_Tools.Tools.CommonTools.IsEmptyString(Context.Context.ServiceBaseInfo.LogAddress))
        {
            Log.Logger.InitLogger(Context.Context.ServiceBaseInfo.LogAddress);
        }
        else
        {
            Log.Logger.InitLogger(null);
        }
    }

    private static TServer server = null!;
    private static bool _restarting = false;
    public static void StopService()
    {
        server.Stop();
    }
    public static void RestartService()
    {
        _restarting = true;
        server.Stop();
    }
    private static async Task StartService(ITAsyncProcessor processor, int port)
    {
        Thrift.Transport.Server.TServerSocketTransport transport = new(
            new System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, port),
            new TConfiguration(),
            1000);
        ProcessorProxy proxy = new(processor);
        server = new Thrift.Server.TThreadPoolAsyncServer(proxy, transport);
        Console.WriteLine("启动服务");
        Console.WriteLine("服务地址:" + Context.Context.ServiceBaseInfo.ServiceIP + ":" + Context.Context.ServiceBaseInfo.ServicePort);

        CronJob.CronJob.AddJob(() =>
        {
            Ready = true;
            Console.WriteLine("服务启动成功");
        }, 1, 5);
        await server.ServeAsync(new CancellationToken());
        if (_restarting)
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory;
            var shellPath = path + "restart.sh";
            if (!File.Exists(shellPath))
            {
                Console.WriteLine($"未找到重启脚本:{shellPath},请手动重启服务");
                return;
            }
            Process.Start("sh", shellPath + " " + System.Diagnostics.Process.GetCurrentProcess().Id.ToString());
        }
    }
    private static async Task StartService(ITAsyncProcessor processor, string? connectionString, int port = 0, Action? preStart = null)
    {
        try
        {
            if (port == ERR_PORT)
                port = GetLegalPort();
            if (port == ERR_PORT)
                throw new Exception("未找到18000到18999之间的空闲端口,服务未能正常启动");
            await InitServices(connectionString, port);

            if (!CUGOJ.CUGOJ_Tools.Tools.CommonTools.IsEmptyString(Context.Context.ServiceBaseInfo.TraceAddress))
            {
                using var provider = InitTraceProvider(ServiceName, Context.Context.ServiceBaseInfo.TraceAddress);
                Console.WriteLine("已初始化链路追踪");
                if (preStart != null)
                    preStart();
                await StartService(processor, port);
            }
            else
            {
                if (preStart != null)
                    preStart();
                await StartService(processor, port);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public static async Task StartBaseService<T>(string connectionString, Action? preStart = null) where T : class, CUGOJ.RPC.Gen.Services.Base.BaseService.IAsync
    {
        Console.WriteLine("正在启动Base服务");

        var handler = Trace.TraceFactory.CreateTracableObject<T>(new ServiceInterceptor());
        CUGOJ.RPC.Gen.Services.Base.BaseService.AsyncProcessor processor = new(handler);
        try
        {
            ServiceType = CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Base;
            await StartService(processor, connectionString, 0, preStart);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public static async Task StartAuthenticationService<T>(string connectionString, Action? preStart = null) where T : class, CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.IAsync
    {
        Console.WriteLine("正在启动Authentication服务");

        var handler = Trace.TraceFactory.CreateTracableObject<T>(new ServiceInterceptor());
        CUGOJ.RPC.Gen.Services.Authentication.AuthenticationService.AsyncProcessor processor = new(handler);
        try
        {
            ServiceType = CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Authentication;
            await StartService(processor, connectionString, 0, preStart);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

}
