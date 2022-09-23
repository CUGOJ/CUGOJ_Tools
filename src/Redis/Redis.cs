using ServiceStack.Redis;
using CUGOJ.CUGOJ_Tools.Log;
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
            try
            {
                using var client = _client;
                if (client == null) return;
                var json = System.Text.Json.JsonSerializer.Serialize<T>(value);
                client.Set(key, json, expireTime);
            }
            catch (Exception e)
            {
                Logger.Warn("Redis: Set抛出异常, {0}.", e);
                return;
            }
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

    public virtual async Task AddToZSet<T>(string key, T obj, double score, TimeSpan expireTime = new TimeSpan())
    {
        await Task.Run(() =>
        {
            using var client = _client;
            if (client == null)
            {
                return;
            }
            var json = System.Text.Json.JsonSerializer.Serialize<T>(obj);
            client.AddItemToSortedSet(key, json, score);
            if (expireTime != TimeSpan.Zero)
            {
                client.ExpireEntryIn(key, expireTime);
            }
        });
    }

    public virtual async Task<List<T>?> GetFromZSet<T>(string key, long cursor, long limit)
    {
        return await Task.Run(() =>
        {
            try
            {
                using var client = _client;
                if (client == null)
                {
                    return null;
                }
                List<string> jsonList = client.GetRangeFromSortedSet(key, (int)cursor, (int)(cursor + limit - 1));
                List<T> res = new();
                foreach (string json in jsonList)
                {
                    T? obj = System.Text.Json.JsonSerializer.Deserialize<T>(json);
                    if (obj == null)
                    {
                        Logger.Warn("Redis查询ZSet返回值包含null.");
                        return null;
                    }
                    res.Add(obj);
                }
                return res;
            }
            catch (Exception e)
            {
                Logger.Warn("Redis: GetFromZSet抛出异常, {0}.", e);
                return null;
            }
        });
    }

    public virtual async Task<List<T>?> GetFromZSet<T>(string key, double low, double up, long cursor, long limit)
    {
        return await Task.Run(() =>
        {
            try
            {
                using var client = _client;
                if (client == null)
                {
                    return null;
                }
                List<string> jsonList = client.GetRangeFromSortedSetByHighestScore(key, low, up, (int)cursor, (int)limit);
                List<T> res = new();
                foreach (string json in jsonList)
                {
                    T? obj = System.Text.Json.JsonSerializer.Deserialize<T>(json);
                    if (obj == null)
                    {
                        Logger.Warn("Redis查询ZSet返回值包含null.");
                        return null;
                    }
                    res.Add(obj);
                }
                return res;
            }
            catch (Exception e)
            {
                Logger.Warn("Redis: GetFromZSet抛出异常, {0}.", e);
                return null;
            }
        });
    }

    public delegate Task<T?> QueryDBFunction<T, E>(E req);

    public virtual async Task<T?> GetWithCacheKey<T, E>(QueryDBFunction<T, E> queryDBFunction, E req, string key, int expireSeconds = 5) where T : class
    {
        string lockKey = "cache_lock_" + key;
        string contentKey = key;
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

    public delegate Task<List<T>> MulQueryDBFunction<T, E>(E req);
    public delegate double GetScoreFunction<T>(T obj);
    public virtual async Task<List<T>> GetWithZSetCache<T, E>(MulQueryDBFunction<T, E> mulQueryDBFunction, GetScoreFunction<T> getScoreFunction, E req, string key, long cursor, long limit, int expireSeconds = 20) where T : class
    {
        string lockKey = "cache_lock_" + key;
        string contentKey = key;
        using var client = _client;
        if (client == null)
        {
            return await mulQueryDBFunction(req);
        }
        if (client.SetValueIfNotExists(lockKey, "1", TimeSpan.FromSeconds(expireSeconds)))
        {
            List<T> res = await mulQueryDBFunction(req);
            foreach (T obj in res)
            {
                await AddToZSet<T>(contentKey, obj, getScoreFunction(obj), TimeSpan.FromSeconds(expireSeconds + 2));
            }
            return res;
        }
        else
        {
            List<T>? res = await GetFromZSet<T>(contentKey, cursor, limit);
            if (res == null)
            {
                return await mulQueryDBFunction(req);
            }
            return res;
        }
    }

    public virtual async Task<List<T>> GetWithZSetCache<T, E>(MulQueryDBFunction<T, E> mulQueryDBFunction, GetScoreFunction<T> getScoreFunction, E req, string key, double low, double up, long cursor, long limit, int expireSeconds = 20) where T : class
    {
        string lockKey = "cache_lock_" + key;
        string contentKey = key;
        using var client = _client;
        if (client == null)
        {
            return await mulQueryDBFunction(req);
        }
        if (client.SetValueIfNotExists(lockKey, "1", TimeSpan.FromSeconds(expireSeconds)))
        {
            List<T> res = await mulQueryDBFunction(req);
            foreach (T obj in res)
            {
                await AddToZSet<T>(contentKey, obj, getScoreFunction(obj), TimeSpan.FromSeconds(expireSeconds + 2));
            }
            return res;
        }
        else
        {
            List<T>? res = await GetFromZSet<T>(contentKey, low, up, cursor, limit);
            if (res == null)
            {
                return await mulQueryDBFunction(req);
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