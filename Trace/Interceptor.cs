using Castle.Core;
using Castle.DynamicProxy;
using System.Diagnostics;
using System.Collections.Concurrent;
namespace CUGOJ.CUGOJ_Tools.Trace
{
    public class Interceptor : IInterceptor
    {
        internal static ActivitySource _source = new ActivitySource("unknown");
        private static object _onceLock = new object();
        private static int _onceLockCounter = 0;
        public static void InitIntercepor(ActivitySource source)
        {
            lock (_onceLock)
            {
                Interlocked.Increment(ref _onceLockCounter);
                _source = source;
            }
        }
        private bool _recordReq;
        private bool _recordResp;
        public Interceptor(bool recordReq = false, bool recordResp = false)
        {
            _recordReq = recordReq;
            _recordResp = recordResp;
        }
        public virtual void Intercept(IInvocation invocation)
        {
            using (var activity = _source.StartActivity(invocation.Method.Name))
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
                }
                catch (Exception e)
                {
                    activity?.SetStatus(ActivityStatusCode.Error, e.Message);
                }
                AfterProcess(activity, invocation);
            }
        }
        internal virtual void PreProcess(Activity? activity, IInvocation invocation)
        {

        }

        internal virtual void AfterProcess(Activity? activity, IInvocation invocation)
        {

        }
    }
}