using Castle.Core;
using Castle.DynamicProxy;
using System.Diagnostics;
using System.Collections.Concurrent;
using CUGOJ.RPC.Gen.Base;
namespace CUGOJ.CUGOJ_Tools.Trace
{
    public class ServiceInterceptor : Interceptor
    {
        private Base? GetBase(object[] requests)
        {
            foreach (var req in requests)
            {
                var propertie = req.GetType().GetProperty("Base");
                if (propertie != null && propertie.PropertyType == typeof(Base))
                {
                    return propertie.GetValue(req) as Base;
                }
            }
            return null;
        }
        private void CheckBaseResp(object resp, Exception? e = null)
        {
            var propertie = resp.GetType().GetProperty("BaseResp");
            if (propertie != null && propertie.PropertyType == typeof(BaseResp))
            {
                var baseResp = propertie.GetValue(resp) as BaseResp;
                if (baseResp == null)
                {
                    if (e == null)
                        propertie.SetValue(resp, CUGOJ.CUGOJ_Tools.RPC.RPCTools.SuccessBaseResp());
                    else
                        propertie.SetValue(resp, CUGOJ.CUGOJ_Tools.RPC.RPCTools.ErrorBaseResp(e));
                }
            }
        }

        public override void Intercept(IInvocation invocation)
        {
            Base? baseReq = GetBase(invocation.Arguments);
            if (baseReq != null && baseReq.Extra != null && baseReq.Extra.ContainsKey("TraceContext") && baseReq.Extra.ContainsKey("ServiceID"))
            {
                var TraceContextData = baseReq.Extra["TraceContext"];
                Context.Context.ServiceID = baseReq.Extra["ServiceID"];
                if (baseReq.Extra.ContainsKey("UserID"))
                    Context.Context.UserID = baseReq.Extra["UserID"];
                ActivityContext context;
                if (ActivityContext.TryParse(TraceContextData, null, out context))
                {
                    using (var activity = _source.StartActivity(invocation.Method.Name, ActivityKind.Server, context))
                    {
                        foreach (var attr in invocation.Method.GetCustomAttributes(false))
                        {
                            if (attr is TagAttribute)
                            {
                                ((TagAttribute)attr).AddTags((key, value) =>
                                {
                                    activity?.AddTag(key, value);
                                });
                            }
                        }
                        activity?.SetTag("IP", Context.Context.ServiceBaseInfo.ServiceIP);
                        activity?.SetTag("Method", Context.Context.Method);
                        activity?.SetTag("Env", Context.Context.ServiceBaseInfo.Env);
                        activity?.SetTag("ServiceID", Context.Context.ServiceBaseInfo.ServiceID);
                        activity?.SetStatus(ActivityStatusCode.Ok);
                        PreProcess(activity, invocation);
                        try
                        {
                            invocation.Proceed();
                            CheckBaseResp(invocation.ReturnValue, null);
                        }
                        catch (Exception e)
                        {
                            activity?.SetStatus(ActivityStatusCode.Error, e.Message);
                            CheckBaseResp(invocation.ReturnValue, e);
                        }
                        AfterProcess(activity, invocation);
                    }
                    return;
                }
            }
            else
            {
                throw new Exception("未知的请求来源,拒绝访问");
            }
        }
        internal override void PreProcess(Activity? activity, IInvocation invocation)
        {

        }
    }
}