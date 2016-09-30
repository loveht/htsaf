using System;

namespace Ataoge.Dependency
{
    public interface IProxyProvider
    {
        object GetProxyObject(Type targetType, object targetObject);
    }
}