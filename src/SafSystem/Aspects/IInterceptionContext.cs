using System;
using System.Reflection;

namespace Ataoge.Aspects
{
    public interface IInterceptionContext
    {
        object Target {get;}

        MethodInfo Method { get;}

        object[] Arguments { get; }

        object ReturnValue { get; }

        Action Process { get;}

        bool Handled { get; set; }
    }

    public interface IInterceptor
    {
        void PerformProceed(IInterceptionContext context);
    }

    public interface IInterceptor<TAspect>: IInterceptor
    {
        TAspect Aspect { get; set;}

        
    }
}