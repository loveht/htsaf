using System;
using Microsoft.Extensions.DependencyInjection;

namespace Ataoge.Dependency
{
    internal class SafScopeFactory : IServiceScopeFactory
	{
		private readonly SafServiceProvider _provider;

		public SafScopeFactory(IServiceProvider provider)
		{
            if (provider is SafServiceProvider)
			    this._provider = provider as  SafServiceProvider;
            else
                throw new SafException("SafServiceProvider");
		}
		public IServiceScope CreateScope()
		{
			return new SafServiceScope(new SafServiceProvider(this._provider));
		}
	}
}