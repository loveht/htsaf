namespace Ataoge.Aspects
{
    public class CastleInterceptionContext : AbstractInterceptionContext
    {
        public CastleInterceptionContext(Castle.DynamicProxy.IInvocation invocation)
                :base(invocation.InvocationTarget, invocation.Method, invocation.Arguments)
        {
            this.invocation = invocation;
            this.Process = this.ProcessInvocation;
        }

        private Castle.DynamicProxy.IInvocation invocation;

        private void ProcessInvocation()
        {
            this.invocation.Proceed();
            base.Handled = true;
            base.ReturnValue = this.invocation.ReturnValue;
        }
    }
}