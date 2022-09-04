using Castle.DynamicProxy;

namespace CUGOJ.CUGOJ_Tools.Trace
{
    public static class TraceFactory
    {
        private static ProxyGenerator generator = new();
        public static T CreateTracableObject<T>(bool recordReq = false, bool recordResp = false) where T : class
        {
            IInterceptor interceptor = new Interceptor(recordReq, recordResp);
            return generator.CreateClassProxy<T>(interceptor);
        }
        public static T CreateTracableObject<T>(IInterceptor? interceptor = null) where T : class
        {
            if (interceptor == null)
            {
                interceptor = new Interceptor(false, false);
            }
            return generator.CreateClassProxy<T>(interceptor);
        }

    }
}