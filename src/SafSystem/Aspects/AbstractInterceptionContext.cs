using System;
using System.Reflection;

namespace Ataoge.Aspects
{
    public class AbstractInterceptionContext : IInterceptionContext
    {
        public AbstractInterceptionContext(object target, MethodInfo method, object[] arguments)
        {
            this.Target = target;
            this.Method = method;
            this.Arguments = arguments;
        }
        
        public object[] Arguments
        {
            get;
            private set;
        }

        public bool Handled
        {
            get;
            set;
        }

        public MethodInfo Method
        {
            get;
            private set;
        }

        public Action Process
        {
            get;
            set;
            
        }

        public object ReturnValue
        {
            get;
            set;
        }

        public object Target
        {
            get;
            private set;
        }
    }
}