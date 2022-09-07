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
    public static readonly string BaseServiceName = "CUGOJ.Base";
    public static readonly string CoreServiceName = "CUGOJ.Core";
    public static readonly string FileServiceName = "CUGOJ.File";
    public static readonly string AuthenticationServiceName = "CUGOJ.Authentication";
    public static readonly int MIN_PORT = 18000;
    public static readonly int MAX_PORT = 18999;
    public static readonly int ERR_PORT = 0;
    public static readonly int NULL_PORT = 0;

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


    private static async Task InitServices(string serviceName, string? connectionString, int port)
    {
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
        else if (connectionString != null)
        {
            using var activity = new Activity(serviceName);
            activity.Start();
            try
            {
                var serviceBaseInfo = await ConnectCore(connectionString, port);
                Context.Context.ServiceBaseInfo = serviceBaseInfo;
                Console.WriteLine("成功连接到Core服务");
                Console.WriteLine("服务信息:\n" + System.Text.Json.JsonSerializer.Serialize<CUGOJ.RPC.Gen.Base.ServiceBaseInfo>(serviceBaseInfo));
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
        Interceptor.InitIntercepor(new(serviceName));
        if (Context.Context.ServiceBaseInfo.LogAddress != string.Empty)
        {
            Log.Logger.InitLogger(Context.Context.ServiceBaseInfo.LogAddress);
        }
        else
        {
            Log.Logger.InitLogger(null);
        }
    }


    private static async Task StartService(ITAsyncProcessor processor, int port)
    {
        Thrift.Transport.Server.TServerSocketTransport transport = new(
            new System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, port),
            new TConfiguration(),
            1000);
        ProcessorProxy proxy = new(processor);
        TServer server = new Thrift.Server.TThreadPoolAsyncServer(proxy, transport);
        Console.WriteLine("启动服务");
        Console.WriteLine("服务地址:" + Context.Context.ServiceBaseInfo.ServiceIP + ":" + Context.Context.ServiceBaseInfo.ServicePort);

        Task.Delay(1000).ContinueWith((t) =>
        {
            Ready = true;
            Console.WriteLine("服务启动成功");
        });
        await server.ServeAsync(new CancellationToken());
    }
    private static async Task StartService(string serviceName, ITAsyncProcessor processor, string? connectionString, int port = 0, Action? preStart = null)
    {
        try
        {
            if (port == ERR_PORT)
                port = GetLegalPort();
            if (port == ERR_PORT)
                throw new Exception("未找到18000到18999之间的空闲端口,服务未能正常启动");
            await InitServices(serviceName, connectionString, port);

            if (Context.Context.ServiceBaseInfo.TraceAddress != string.Empty)
            {
                using var provider = InitTraceProvider(serviceName, Context.Context.ServiceBaseInfo.TraceAddress);
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
            await StartService(BaseServiceName, processor, connectionString, 0, preStart);
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
            await StartService(AuthenticationServiceName, processor, connectionString, 0, preStart);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

}
