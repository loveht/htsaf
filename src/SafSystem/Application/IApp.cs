using System;

namespace Ataoge.Application
{
    /// <summary>
    /// Represents that the implemented classes are Ataoge applications. 
    /// </summary>
    public interface IApp
    {
        /// <summary>
        /// Starts the application. 
        /// </summary>
        IApp Start();

        void Start(Action<IApp> action);
    }
}