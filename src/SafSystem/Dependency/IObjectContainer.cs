using System;

namespace Ataoge.Dependency
{
    public interface IObjectContainer : IServiceRegister, IServiceResolver, IDisposable
    {
        T GetWrappedContainer<T>();
    }
}