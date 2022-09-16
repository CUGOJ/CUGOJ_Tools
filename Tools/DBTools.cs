using Microsoft.EntityFrameworkCore;
namespace CUGOJ.CUGOJ_Tools.Tools;

public static class DBTools
{
    public enum SqliteStatus
    {
        Exists,
        NotFound,
        NoDbPath
    }
    public static SqliteStatus CheckSqliteExist<T>(T context) where T : DbContext
    {
        var contextType = typeof(T);
        var DbPathProperties = contextType.GetProperty("DbPath");
        if (DbPathProperties == null) return SqliteStatus.NoDbPath;
        var DbPath = DbPathProperties.GetValue(context) as string;
        if (DbPath == null) return SqliteStatus.NoDbPath;
        return File.Exists(DbPath) ? SqliteStatus.Exists : SqliteStatus.NotFound;
    }

    public static bool CreateParentPath<T>(T context) where T : DbContext
    {
        var contextType = typeof(T);
        var DbPathProperties = contextType.GetProperty("DbPath");
        if (DbPathProperties == null) return false;
        var DbPath = DbPathProperties.GetValue(context) as string;
        if (DbPath == null) return false;
        DbPath = Path.GetDirectoryName(DbPath);
        if (DbPath == null) return false;
        try
        {
            Directory.CreateDirectory(DbPath);
        }
        catch (Exception e)
        {
            Console.WriteLine("创建目录失败,Error={Error}", e);
            return false;
        }
        return true;
    }

    public static bool InitSqlite<T>() where T : DbContext
    {
        try
        {
            var constructor = typeof(T).GetConstructor(new Type[] { });
            if (constructor == null)
            {
                throw new Exception("未找到无参构造函数,Type=" + typeof(T).FullName);
            }
            using var context = constructor.Invoke(new Type[] { }) as T;
            if (context == null)
            {
                throw new Exception("实例化Context失败,Type=" + typeof(T).FullName);
            }
            switch (CheckSqliteExist(context))
            {
                case SqliteStatus.Exists:
                    return true;
                case SqliteStatus.NoDbPath:
                    Console.WriteLine("传入的context类型没有DbPath属性或属性未设置");
                    return false;
            }
            Console.WriteLine("首次启动系统,开始初始化Sqlite:" + typeof(T).Name);
            if (!CreateParentPath<T>(context))
            {
                return false;
            }
            var res = context.Database.EnsureCreated();
            if (res)
            {
                Console.WriteLine("Sqlite初始化成功");
            }
            else
            {
                Console.WriteLine("Sqlite初始化失败,请检查系统配置");
            }
            return res;
        }
        catch (Exception e)
        {
            Log.Logger.Error("初始化Sqlite出错,Error = {Error}", e);
            return false;
        }
    }
}