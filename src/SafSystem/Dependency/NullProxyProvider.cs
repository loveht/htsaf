using System;

namespace Ataoge.Dependency
{
    public class NullProxyProvider : IProxyProvider
    {
        public object GetProxyObject(Type targetType, object targetObject)
        {
            return targetObject;
        }
    }
}