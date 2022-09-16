using Microsoft.EntityFrameworkCore;
namespace CUGOJ.CUGOJ_Tools.RPC.Dao;

public class RPCContext : DbContext
{
    public DbSet<ServiceInfo> ServiceInfos { get; set; } = null!;
    public string DbPath { get; }
    public RPCContext()
    {
        DbPath = "./data/rpc.db";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}

public class ServiceInfo
{
    public long Id { get; set; }
    public string CoreIP { get; set; } = string.Empty;
    public int CorePort { get; set; } = 0;
    public string Token { get; set; } = string.Empty;
    public string ServiceID { get; set; } = string.Empty;
}