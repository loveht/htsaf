using System;

namespace Ataoge.Dependency
{
    public interface IServiceRegister
    {
        /// <summary>
        /// Registers a type as self registration.
        /// </summary>
        /// <typeparam name="T">Type of the class</typeparam>
        /// <param name="lifeStyle">LifeTimeStyle of the objects of this type</param>
        void Register<T>(LifeTimeStyle lifeTimeStyle = LifeTimeStyle.Singleton)
            where T : class;
        
        /// <summary>
        /// Registers a type as self registration.
        /// </summary>
        /// <param name="type">Type of the class</param>
        /// <param name="lifeTimeStyle">LifeTimeStyle of the objects of this type</param>
        void Register(Type type, LifeTimeStyle lifeTimeStyle = LifeTimeStyle.Singleton);

        /// <summary>
        /// Registers a type with it's implementation.
        /// </summary>
        /// <typeparam name="TType">Registering type</typeparam>
        /// <typeparam name="TImpl">The type that implements <see cref="TType"/></typeparam>
        /// <param name="lifeTimeStyle">LifeTimeStyle of the objects of this type</param>
        void Register<TType, TImpl>(LifeTimeStyle lifeTimeStyle = LifeTimeStyle.Singleton)
            where TType : class
            where TImpl : class, TType;

        /// <summary>
        /// Registers a type with it's implementation.
        /// </summary>
        /// <param name="type">Type of the class</param>
        /// <param name="impl">The type that implements <paramref name="type"/></param>
        /// <param name="lifeTimeStyle">LifeTimeStyle of the objects of this type</param>
        void Register(Type type, Type impl, LifeTimeStyle lifeTimeStyle = LifeTimeStyle.Singleton);

        void Register(Type type, object instance);

        void Register<TType>(TType instance) where TType : class;

        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <param name="type">Type to check</param>
        bool IsRegistered(Type type);

        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <typeparam name="TType">Type to check</typeparam>
        bool IsRegistered<TType>();
    }
}