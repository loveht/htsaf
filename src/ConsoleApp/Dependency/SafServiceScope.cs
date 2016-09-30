using System;
using Microsoft.Extensions.DependencyInjection;

namespace Ataoge.Dependency
{
    internal class SafServiceScope : IServiceScope, IDisposable
	{
		private readonly SafServiceProvider _scopedProvider;
		public IServiceProvider ServiceProvider
		{
			get
			{
				return this._scopedProvider;
			}
		}
		public SafServiceScope(SafServiceProvider scopedProvider)
		{
			this._scopedProvider = scopedProvider;
		}
		public void Dispose()
		{
			this._scopedProvider.Dispose();
		}
	}
}