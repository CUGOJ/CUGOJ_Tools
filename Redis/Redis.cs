using ServiceStack.Redis;
namespace CUGOJ.CUGOJ_Tools.Redis;

public class RedisProcessor
{
    private PooledRedisClientManager? _clientManager;

    public RedisProcessor()
    {
        _clientManager = new PooledRedisClientManager(CUGOJ.CUGOJ_Tools.Context.Context.ServiceBaseInfo.RedisAddress);
    }

    private IRedisClient? _client
    {
        get
        {
            if (_clientManager == null) return null;
            return _clientManager.GetClient();
        }
    }
    public virtual void SetString(string key, string value, TimeSpan expireTime = new TimeSpan())
    {
        using var client = _client;
        if (client == null) return;
        client.Set(key, value, expireTime);
    }
    public virtual string? GetString(string key)
    {
        using var client = _client;
        if (client == null) return null;
        return client.Get<string>(key);
    }
    public virtual void Set<T>(string key, T value, TimeSpan expireTime = new TimeSpan()) where T : class
    {
        using var client = _client;
        if (client == null) return;
        var json = System.Text.Json.JsonSerializer.Serialize<T>(value);
        client.Set(key, json, expireTime);
    }
    public virtual T? Get<T>(string key) where T : class
    {
        using var client = _client;
        if (client == null) return null;
        var json = client.Get<string>(key);
        if (json == null) return null;
        return System.Text.Json.JsonSerializer.Deserialize<T>(json);
    }
}
public static class RedisContext
{
    private static RedisProcessor? _redisProcessor;
    public static RedisProcessor? Context { get => _redisProcessor; }
    private static object _initLock = new();
    private static int _initCount = 0;
    public static void InitRedis()
    {
        if (_initCount != 0) return;
        lock (_initLock)
        {
            if (_initCount != 0) return;
            _initCount++;
            if (CUGOJ.CUGOJ_Tools.Context.Context.ServiceBaseInfo.RedisAddress != string.Empty &&
            CUGOJ.CUGOJ_Tools.Context.Context.ServiceBaseInfo.RedisAddress != "null")
            {
                _redisProcessor = CUGOJ.CUGOJ_Tools.Trace.TraceFactory.CreateTracableObject<RedisProcessor>(false, false);
            }
        }
    }

}