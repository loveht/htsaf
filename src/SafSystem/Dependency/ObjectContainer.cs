using System;

namespace Ataoge.Dependency
{
    public abstract class ObjectContainer : IObjectContainer
    {
        
        public virtual void Dispose()
        {
    
        }

        public abstract T GetWrappedContainer<T>();
        

        protected abstract bool DoIsRegistered(Type type);
       

        public bool IsRegistered(Type type)
        {
            return this.DoIsRegistered(type);
        }

        protected abstract bool DoIsRegistered<TType>();
       

        public bool IsRegistered<TType>()
        {
            return this.DoIsRegistered<TType>();
        }

        protected abstract void DoRegister(Type type, LifeTimeStyle lifeTimeStyle);
        
        public void Register(Type type, LifeTimeStyle lifeTimeStyle = LifeTimeStyle.Singleton)
        {
            this.DoRegister(type, lifeTimeStyle);
        }

        protected abstract void DoRegister(Type type, Type impl, LifeTimeStyle lifeTimeStyle);

        public void Register(Type type, Type impl, LifeTimeStyle lifeTimeStyle = LifeTimeStyle.Singleton)
        {
            this.DoRegister(type, impl, lifeTimeStyle);
        }

        protected abstract void DoRegister<T>(LifeTimeStyle lifeTimeStyle) where T : class;
        
        public void Register<T>(LifeTimeStyle lifeTimeStyle = LifeTimeStyle.Singleton) where T : class
        {
            this.DoRegister<T>(lifeTimeStyle);
        }

        protected abstract void DoRegister(Type type, object instance);

        protected abstract void DoRegister<TType>(TType instance) where TType : class;

        public void Register(Type type, object instance)
        {
            this.DoRegister(type, instance);
        }

        public void Register<TType>(TType instance) where TType : class
        {
            this.DoRegister<TType>(instance);
        }

        protected abstract object DoResolve(Type type);

        public object Resolve(Type type)
        {
            return this.DoResolve(type);
        }

        protected abstract object DoResolve(Type type, object overridedArguments);
        
        public object Resolve(Type type, object overridedArguments)
        {
            return this.DoResolve(type, overridedArguments);
        }

        protected abstract T DoResolve<T>();
     

        public T Resolve<T>()
        {
            return this.DoResolve<T>();
        }

        protected abstract T DoResolve<T>(object overridedArguments);
        
        public T Resolve<T>(object overridedArguments)
        {
            return this.DoResolve<T>(overridedArguments);
        }

        protected abstract T DoResolve<T>(Type type);
       
        public T Resolve<T>(Type type)
        {
            return this.DoResolve<T>(type);
        }

        protected abstract object[] DoResolveAll(Type type);
       
        public object[] ResolveAll(Type type)
        {
            return this.DoResolveAll(type);
        }

        protected abstract T[] DoResolveAll<T>();
       

        public T[] ResolveAll<T>()
        {
            return this.DoResolveAll<T>();
        }

        protected abstract void DoRegister<TType, TImpl>(LifeTimeStyle lifeTimeStyle)
            where TType : class
            where TImpl : class, TType;
        

        public void Register<TType, TImpl>(LifeTimeStyle lifeTimeStyle =  LifeTimeStyle.Singleton) 
            where TType : class 
            where TImpl : class, TType
        {
            this.DoRegister<TType, TImpl>(lifeTimeStyle);
        }


    }
}