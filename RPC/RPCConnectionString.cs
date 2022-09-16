namespace CUGOJ.CUGOJ_Tools.RPC;

public class RPCRegisterInfo
{

    public static RPCRegisterInfo NewRPCRegisterInfoByConnectionString(string connectionString)
    {
        try
        {
            connectionString = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(connectionString));
            var registerInfo = System.Text.Json.JsonSerializer.Deserialize<RPCRegisterInfo>(connectionString);
            if (registerInfo == null)
            {
                throw new Exception();
            }
            return registerInfo;
        }
        catch (Exception)
        {
            Console.WriteLine("非法的连接串");
            throw new Exception("非法的字符串");
        }
    }
    public override string ToString()
    {
        var connectionStringBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes<RPCRegisterInfo>(this);
        return Convert.ToBase64String(connectionStringBytes);
    }
    public string ServiceID { get; set; } = string.Empty;
    public string CoreIP { get; set; } = string.Empty;
    public int CorePort { get; set; } = 0;
    public string Token { get; set; } = string.Empty;
    public CUGOJ.RPC.Gen.Base.ServiceTypeEnum ServiceType { get; set; } = CUGOJ.RPC.Gen.Base.ServiceTypeEnum.Core;
}