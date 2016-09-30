using System;
using Microsoft.Extensions.DependencyInjection;

namespace Ataoge.Dependency
{
    public class SafServiceProvider : IServiceProvider, ISupportRequiredService, IDisposable
    {
        internal SafServiceProvider(SafServiceProvider parent)
        {
            this._root = parent;
        }

        private readonly SafServiceProvider _root;

        public SafServiceProvider(IServiceResolver serviceResolver)
        {
            this.serviceResolver = serviceResolver;
            this._root = this;
        }

        private readonly IServiceResolver serviceResolver;

        public object GetRequiredService(Type serviceType)
        {
            if (this.serviceResolver != null)
            {
                return this.serviceResolver.Resolve(serviceType);
            }
            return this._root.GetRequiredService(serviceType);
        }

        public object GetService(Type serviceType)
        {
            if (this.serviceResolver != null)
                return this.serviceResolver.Resolve(serviceType);
            return this._root.GetService(serviceType);
        }

        public void Dispose()
        {
            this._root.Dispose();
        }
    }
}