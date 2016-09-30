namespace Ataoge.Aspects
{
    public class WrappedInterception : Castle.DynamicProxy.IInterceptor
    {
        public WrappedInterception(Ataoge.Aspects.IInterceptor interceptor)
        {
            this.Interceptor = interceptor;
        }

        public Ataoge.Aspects.IInterceptor Interceptor
        {
            get;
            private set;
        }

        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
            CastleInterceptionContext interceptionContext = new CastleInterceptionContext(invocation);
            this.Interceptor.PerformProceed(interceptionContext);
        }
    }
}