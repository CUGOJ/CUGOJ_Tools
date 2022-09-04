using CUGOJ.RPC.Gen.Base;
namespace CUGOJ.CUGOJ_Tools.RPC;

public static class RPCTools
{
    public enum RPCStatus
    {
        OK = 0,
        Error = 1
    }

    public static BaseResp SuccessBaseResp()
    {
        return new BaseResp(((int)RPCStatus.OK));
    }

    public static BaseResp ErrorBaseResp(Exception? e = null)
    {
        BaseResp resp = new BaseResp(((int)RPCStatus.Error));
        if (e != null)
        {
            resp.Extra.Add("ErrorMsg", e.Message);
        }
        else
        {
            resp.Extra.Add("ErrorMsg", "远程调用出错");
        }
        return resp;
    }

    public static Base NewBase()
    {
        var res = new Base();
        res.Extra = new();
        var activity = System.Diagnostics.Activity.Current;
        if (activity != null)
        {
            res.Extra["TraceContext"] = activity.Id;
        }
        return res;
    }

}