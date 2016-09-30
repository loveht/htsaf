using System;

namespace Ataoge.Logging
{
    /// <summary>
    /// Interface for LogManager
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// Gets or sets the adapter.
        /// </summary>
        /// <value>The adapter.</value>
        ILoggerFactoryAdapter Adapter { get; set; }

        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(Type)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified type.
        /// </summary>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
        ILog GetLogger<T>();

        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(Type)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
        ILog GetLogger(Type type);

        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(string)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
        ILog GetLogger(string key);

    }
}