using CUGOJ.RPC.Gen.Base;
namespace CUGOJ.CUGOJ_Tools.Context;

public static class Context
{
    private static ServiceBaseInfo _serviceBaseInfo = new();
    private static object _serviceBaseInfoLock = new();
    private static int _serviceBaseInfoCount = 0;
    public static bool Debug { get; set; } = false;
    public static ServiceBaseInfo ServiceBaseInfo
    {
        get => _serviceBaseInfo;
        set
        {
            lock (_serviceBaseInfoLock)
            {
                if (_serviceBaseInfoCount != 0)
                    return;
                _serviceBaseInfoCount++;
                _serviceBaseInfo = value;
            }
        }
    }

    private static string _serviceName = string.Empty;
    private static int _serviceNameCount = 0;
    private static object _serviceNameLock = new();
    public static string ServiceName
    {
        get => _serviceName;
        set
        {
            lock (_serviceNameLock)
            {
                if (_serviceNameCount != 0) return;
                _serviceNameCount++;
                _serviceName = value;
            }
        }
    }
    private static AsyncLocal<string> _clientIP = new();
    public static string? ClientIP
    {
        get => _clientIP.Value;
        set => _clientIP.Value = value != null ? value : string.Empty;
    }
    private static AsyncLocal<string> _method = new();
    public static string? Method
    {
        get => _method.Value;
        set => _method.Value = value != null ? value : string.Empty;
    }
}