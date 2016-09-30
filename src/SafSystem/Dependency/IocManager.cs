using System;
using System.Collections.Generic;

namespace Ataoge.Dependency
{
    public class IocManager : IObjectContainer
    {
        /// <summary>
        /// The Singleton instance.
        /// </summary>
        public static IocManager Instance { get; private set; }

        static IocManager()
        {
            Instance = new IocManager();
        }

        private IocManager()
        {
            ProxyProvider = new NullProxyProvider();
        }

        public IObjectContainer ObjectContainer
        {
            get;
            set;
        }

        public IProxyProvider ProxyProvider
        {
            get;
            set;
        }


        public void Dispose()
        {
            ObjectContainer?.Dispose();
        }

        public T GetWrappedContainer<T>()
        {
            return ObjectContainer.GetWrappedContainer<T>();
        }

        protected virtual bool DoIsRegistered(Type type)
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered(Type type)
        {
            return (ObjectContainer as IServiceRegister).IsRegistered(type);
        }

  
        public bool IsRegistered<TType>()
        {
            return (ObjectContainer as IServiceRegister).IsRegistered<TType>();
        }


        public void Register(Type type, LifeTimeStyle lifeTimeStyle = LifeTimeStyle.Singleton)
        {
            ObjectContainer.Register(type, lifeTimeStyle);
        }

        public void Register(Type type, Type impl, LifeTimeStyle lifeTimeStyle = LifeTimeStyle.Singleton)
        {
            ObjectContainer.Register(type, impl, lifeTimeStyle);
        }

        public void Register<T>(LifeTimeStyle lifeTimeStyle = LifeTimeStyle.Singleton) where T : class
        {
            ObjectContainer.Register<T>(lifeTimeStyle);
        }

        public void Register(Type type, object instance)
        {
            ObjectContainer.Register(type, instance);
        }

        public void Register<TType>(TType instance) where TType : class
        {
            ObjectContainer.Register<TType>(instance);
        }

        public object Resolve(Type type)
        {
            object o = ObjectContainer.Resolve(type);
            return this.ProxyProvider.GetProxyObject(type, o);
        }

        public object Resolve(Type type, object overridedArguments)
        {
            object o = ObjectContainer.Resolve(type, overridedArguments);
            return this.ProxyProvider.GetProxyObject(type, o);
        }

        public T Resolve<T>()
        {
            T t = ObjectContainer.Resolve<T>();
            return (T)this.ProxyProvider.GetProxyObject(typeof(T), t);
        }

       
        public T Resolve<T>(object overridedArguments)
        {
            T t = ObjectContainer.Resolve<T>(overridedArguments);
            return (T)this.ProxyProvider.GetProxyObject(typeof(T), t);
        }

       public T Resolve<T>(Type type)
        {
            T t = ObjectContainer.Resolve<T>(type);
            return (T)this.ProxyProvider.GetProxyObject(typeof(T), t);
        }


        public object[] ResolveAll(Type type)
        {
            var serviceImpls = ObjectContainer.ResolveAll(type);
            List<object> proxiedObjects = new List<object>();
            foreach (var serviceImpl in serviceImpls)
                proxiedObjects.Add(this.ProxyProvider.GetProxyObject(type, serviceImpl));
            return proxiedObjects.ToArray();
        }

        public T[] ResolveAll<T>()
        {
            var serviceImpls = ObjectContainer.ResolveAll<T>();
            List<T> proxiedObjects = new List<T>();
            foreach (var serviceImpl in serviceImpls)
                proxiedObjects.Add((T)this.ProxyProvider.GetProxyObject(typeof(T), serviceImpl));
            return proxiedObjects.ToArray();
        }

        public void Register<TType, TImpl>(LifeTimeStyle lifeTimeStyle =  LifeTimeStyle.Singleton) 
            where TType : class 
            where TImpl : class, TType
        {
            ObjectContainer.Register<TType, TImpl>(lifeTimeStyle);
        }

       
    }
}