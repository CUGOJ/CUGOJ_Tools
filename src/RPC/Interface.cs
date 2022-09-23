namespace CUGOJ.CUGOJ_Tools.RPC;

public interface BaseRequest
{
    public CUGOJ.RPC.Gen.Base.Base Base { get; set; }
}

public interface BaseResponse
{
    public CUGOJ.RPC.Gen.Base.BaseResp BaseResp { get; set; }
}