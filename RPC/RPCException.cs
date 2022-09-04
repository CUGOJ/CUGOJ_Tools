namespace CUGOJ.CUGOJ_Tools.RPC;

public class RPCException
{
    public string Message;
    public RPCException()
    {
        Message = "远程调用出错";
    }
    public RPCException(string message)
    {
        Message = message;
    }
}