using System;
using System.Reflection;

namespace Ataoge.Aspects
{
    public sealed class SafInterceptorSelector : Castle.DynamicProxy.IInterceptorSelector
    {
        public Castle.DynamicProxy.IInterceptor[] SelectInterceptors(Type type, MethodInfo method, Castle.DynamicProxy.IInterceptor[] interceptors)
        {
            throw new NotImplementedException();
        }
    }
}