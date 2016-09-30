using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Ataoge.Dependency
{
    public class MsObjectContainer : ObjectContainer
    {
        public MsObjectContainer(IServiceCollection services)
        {
            this.services = services;
        }

        private IServiceCollection services;

        private IServiceProvider seriveProvider;

        internal IServiceProvider ServiceProvider
        {
            get
            {
                if (seriveProvider == null)
                {
                    seriveProvider = this.services.BuildServiceProvider();
                }
                return seriveProvider; //seriveProvider.GetService<IServiceProvider>();
            }
            
        }

        public override T GetWrappedContainer<T>()
        {
            if (typeof(T).IsAssignableFrom(services.GetType()))
                return (T)this.services;
            throw new SafException("The wrapped container type provided by the current object container should be '{0}'.", typeof(IServiceCollection));
        }

        protected override bool DoIsRegistered(Type type)
        {
            foreach (var sd in this.services)
            {
                if (sd.ServiceType == type)
                {
                    return true;
                }
            }
            return false;
        }

        protected override bool DoIsRegistered<TType>()
        {
            return this.DoIsRegistered(typeof(TType));
        }

        protected override void DoRegister(Type type, LifeTimeStyle lifeTimeStyle)
        {
            switch (lifeTimeStyle)
            {
                case LifeTimeStyle.Singleton:
                    services.AddSingleton(type);
                    break;
                case LifeTimeStyle.Transient:
                    services.AddTransient(type);
                    break;
                case LifeTimeStyle.Scoped:
                    services.AddScoped(type);
                    break;
            }
        }

        protected override void DoRegister(Type type, Type impl, LifeTimeStyle lifeTimeStyle)
        {
            switch (lifeTimeStyle)
            {
                case LifeTimeStyle.Singleton:
                    services.AddSingleton(type, impl);
                    break;
                case LifeTimeStyle.Transient:
                    services.AddTransient(type, impl);
                    break;
                case LifeTimeStyle.Scoped:
                    services.AddScoped(type, impl);
                    break;
            }
        }

        protected override void DoRegister<T>(LifeTimeStyle lifeTimeStyle)
        {
            switch (lifeTimeStyle)
            {
                case LifeTimeStyle.Singleton:
                    services.AddSingleton<T>();
                    break;
                case LifeTimeStyle.Transient:
                    services.AddTransient<T>();
                    break;
                case LifeTimeStyle.Scoped:
                    services.AddScoped<T>();
                    break;
            }
        }

        protected override void DoRegister(Type type, object instance)
        {
            services.AddSingleton(type, instance);
        }

        protected override void DoRegister<TType>(TType instance)
        {
            services.AddSingleton<TType>(instance);
        }

        protected override object DoResolve(Type type)
        {
            return this.ServiceProvider.GetService(type);
        }

        protected override object DoResolve(Type type, object overridedArguments)
        {
            
            return this.ServiceProvider.GetService(type);
        }

        protected override T DoResolve<T>()
        {
            return this.ServiceProvider.GetService<T>();
        }

        protected override T DoResolve<T>(object overridedArguments)
        {
            throw new NotImplementedException();
        }

        protected override T DoResolve<T>(Type type)
        {
            throw new NotImplementedException();
        }

        protected override object[] DoResolveAll(Type type)
        {
            return this.ServiceProvider.GetServices(type).ToArray();
        }

        protected override T[] DoResolveAll<T>()
        {
            return this.ServiceProvider.GetServices<T>().ToArray();
        }

        protected override void DoRegister<TType, TImpl>(LifeTimeStyle lifeTimeStyle)
        {
            switch (lifeTimeStyle)
            {
                case LifeTimeStyle.Singleton:
                    services.AddSingleton<TType, TImpl>();
                    break;
                case LifeTimeStyle.Transient:
                    services.AddTransient<TType, TImpl>();
                    break;
                case LifeTimeStyle.Scoped:
                    services.AddScoped<TType, TImpl>();
                    break;
            }
        }
    }
}