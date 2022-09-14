using System.Runtime.InteropServices;
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
    public virtual async Task SetString(string key, string value, TimeSpan expireTime = new TimeSpan())
    {
        await Task.Run(() =>
        {
            using var client = _client;
            if (client == null)
            {
                return;
            }
            client.Set(key, value, expireTime);
        });
    }
    public virtual async Task<string?> GetString(string key)
    {
        return await Task.Run(() =>
        {
            using var client = _client;
            if (client == null) return null;
            return client.Get<string>(key);
        });
    }
    public virtual async Task Set<T>(string key, T value, TimeSpan expireTime = new TimeSpan()) where T : class
    {
        await Task.Run(() =>
        {
            using var client = _client;
            if (client == null) return;
            var json = System.Text.Json.JsonSerializer.Serialize<T>(value);
            client.Set(key, json, expireTime);
        });
    }
    public virtual async Task<T?> Get<T>(string key) where T : class
    {
        return await Task.Run(() =>
        {
            using var client = _client;
            if (client == null) return null;
            var json = client.Get<string>(key);
            if (json == null) return null;
            return System.Text.Json.JsonSerializer.Deserialize<T>(json);
        });
    }
    public delegate Task<T?> QueryDBFunction<T, E>(E req);
    public virtual async Task<T?> GetWithCache<T, E>(QueryDBFunction<T, E> queryDBFunction, E req, string cacheKey, int expireSeconds = 5) where T : class
    {
        string lockKey = "cache_lock_" + cacheKey;
        string contentKey = "cache_content_" + cacheKey;
        using var client = _client;
        if (client == null)
        {
            return await queryDBFunction(req);
        }
        if (client.SetValueIfNotExists(lockKey, "1", TimeSpan.FromSeconds(expireSeconds)))
        {
            T? res = await queryDBFunction(req);
            if (res != null)
                await Set<T>(contentKey, res, TimeSpan.FromSeconds(expireSeconds + 2));
            return res;
        }
        else
        {
            T? res = await Get<T>(contentKey);
            if (res == null)
            {
                res = await queryDBFunction(req);
            }
            return res;
        }
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