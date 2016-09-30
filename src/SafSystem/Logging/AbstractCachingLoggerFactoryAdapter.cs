using System;
using System.Collections.Generic;

namespace Ataoge.Logging
{
    /// <summary>
    /// An implementation of <see cref="ILoggerFactoryAdapter"/> that caches loggers handed out by this factory.
    /// </summary>
    /// <remarks>
    /// Implementors just need to override <see cref="CreateLogger"/>.
    /// </remarks>
    public abstract class AbstractCachingLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
        private readonly Dictionary<string, ILog> _cachedLoggers;

        /// <summary>
        /// Creates a new instance, the logger cache being case-sensitive.
        /// </summary>
        protected AbstractCachingLoggerFactoryAdapter() : this(true)
        { }

        /// <summary>
        /// Creates a new instance, the logger cache being <paramref key="caseSensitiveLoggerCache"/>.
        /// </summary>
        /// <param name="caseSensitiveLoggerCache"></param>
        protected AbstractCachingLoggerFactoryAdapter(bool caseSensitiveLoggerCache)
        {
            _cachedLoggers = (caseSensitiveLoggerCache)
                                 ? new Dictionary<string, ILog>()
                                 : new Dictionary<string, ILog>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Purges all loggers from cache
        /// </summary>
        protected void ClearLoggerCache()
        {
            lock (_cachedLoggers)
            {
                _cachedLoggers.Clear();
            }
        }

        /// <summary>
        /// Create the specified named logger instance
        /// </summary>
        /// <remarks>
        /// Derived factories need to implement this method to create the
        /// actual logger instance.
        /// </remarks>
        protected abstract ILog CreateLogger(string name);

        #region ILoggerFactoryAdapter Members

        /// <summary>
        /// Get a ILog instance by <see cref="Type" />.
        /// </summary>
        /// <param name="type">Usually the <see cref="Type" /> of the current class.</param>
        /// <returns>
        /// An ILog instance either obtained from the internal cache or created by a call to <see cref="CreateLogger"/>.
        /// </returns>
        public ILog GetLogger(Type type)
        {
            return GetLoggerInternal(type.FullName);
        }

        /// <summary>
        /// Get a ILog instance by key.
        /// </summary>
        /// <param name="key">Usually a <see cref="Type" />'s Name or FullName property.</param>
        /// <returns>
        /// An ILog instance either obtained from the internal cache or created by a call to <see cref="CreateLogger"/>.
        /// </returns>
        public ILog GetLogger(string key)
        {
            return GetLoggerInternal(key);
        }

        /// <summary>
        /// Get or create a ILog instance by key.
        /// </summary>
        /// <param name="key">Usually a <see cref="Type" />'s Name or FullName property.</param>
        /// <returns>
        /// An ILog instance either obtained from the internal cache or created by a call to <see cref="CreateLogger"/>.
        /// </returns>
        private ILog GetLoggerInternal(string key)
        {
            ILog log;
            if (!_cachedLoggers.TryGetValue(key, out log))
            {
                lock (_cachedLoggers)
                {
                    if (!_cachedLoggers.TryGetValue(key, out log))
                    {
                        log = CreateLogger(key);
                        if (log == null)
                        {
                            throw new ArgumentException(string.Format("{0} returned null on creating logger instance for key {1}", this.GetType().FullName, key));
                        }
                        _cachedLoggers.Add(key, log);
                    }
                }
            }
            return log;
        }

        #endregion
    }
}
