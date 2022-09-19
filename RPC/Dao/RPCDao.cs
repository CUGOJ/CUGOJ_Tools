using System.Data.Entity;
namespace CUGOJ.CUGOJ_Tools.RPC.Dao;

public static class RPCDao
{
    public static string? GetConnectionString()
    {
        using var context = new RPCContext();
        var ServiceInfo = (from s in context.ServiceInfos select s).FirstOrDefault();
        if (ServiceInfo == null) return null;
        var registerInfo = new RPCRegisterInfo()
        {
            ServiceID = ServiceInfo.ServiceID,
            CoreIP = ServiceInfo.CoreIP,
            CorePort = ServiceInfo.CorePort,
            Token = ServiceInfo.Token,
            ServiceType = RPCService.ServiceType,
        };
        return registerInfo.ToString();
    }

    public static void SaveConnectionString(string connectionString)
    {
        using var context = new RPCContext();
        var storedServiceInfo = (from s in context.ServiceInfos select s).FirstOrDefault();
        var serviceInfo = RPC.RPCRegisterInfo.NewRPCRegisterInfoByConnectionString(connectionString);
        if (storedServiceInfo == null)
        {
            context.ServiceInfos.Add(new ServiceInfo()
            {
                ServiceID = serviceInfo.ServiceID,
                CoreIP = serviceInfo.CoreIP,
                CorePort = serviceInfo.CorePort,
                Token = serviceInfo.Token,
            });
            context.SaveChanges();
        }
    }
}