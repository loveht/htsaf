using System;
using Ataoge.Logging.Simple;

namespace Ataoge.Logging
{
    /// <summary>
    /// Use the LogManager's <see cref="GetLogger(string)"/> or <see cref="GetLogger(System.Type)"/> 
    /// methods to obtain <see cref="ILog"/> instances for logging.
    /// </summary>
    /// <remarks>
    /// For configuring the underlying log system using application configuration, see the example 
    /// at <c>System.Configuration.ConfigurationManager</c>
    /// For configuring programmatically, see the example section below.
    /// </remarks>
    /// <example>
    /// The example below shows the typical use of LogManager to obtain a reference to a logger
    /// and log an exception:
    /// <code>
    /// 
    /// ILog log = LogManager.GetLogger(this.GetType());
    /// ...
    /// try 
    /// { 
    ///   /* .... */ 
    /// }
    /// catch(Exception ex)
    /// {
    ///   log.ErrorFormat("Hi {0}", ex, "dude");
    /// }
    /// 
    /// </code>
    /// The example below shows programmatic configuration of the underlying log system:
    /// <code>
    /// 
    /// // create properties
    /// NameValueCollection properties = new NameValueCollection();
    /// properties[&quot;showDateTime&quot;] = &quot;true&quot;;
    /// 
    /// // set Adapter
    /// Common.Logging.LogManager.Adapter = new 
    /// Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter(properties);
    /// 
    /// </code>
    /// </example>
    /// <seealso cref="ILog"/>
    /// <seealso cref="Adapter"/>
    /// <seealso cref="ILoggerFactoryAdapter"/>
    public class LogManager : ILogManager
    {
        /// <summary>
        /// Performs static 1-time init of LogManager by calling <see cref="Reset()"/>
        /// </summary>
        static LogManager()
        {
            Reset();
        }

        /// <summary>
        /// Reset the <see cref="Common.Logging" /> infrastructure to its default settings. This means, that configuration settings
        /// will be re-read from section <c>&lt;common/logging&gt;</c> of your <c>app.config</c>.
        /// </summary>
        /// <remarks>
        /// This is mainly used for unit testing, you wouldn't normally use this in your applications.<br/>
        /// <b>Note:</b><see cref="ILog"/> instances already handed out from this LogManager are not(!) affected. 
        /// Resetting LogManager only affects new instances being handed out.
        /// </remarks>
        public static void Reset()
        {
            
        }

        private static ILoggerFactoryAdapter _adapter;
        private static readonly object _loadLock = new object();
        private static Type _type;

        public static void SetDefaultLoggerFactoryAdapter(Type type)
        {
            _type = type;
        }

        public static void SetDefaultLoggerFactoryAdapter(string typeName)
        {
            _type = Type.GetType(typeName);
        }

        /// <summary>
        /// Gets or sets the adapter.
        /// </summary>
        /// <value>The adapter.</value>
        public static ILoggerFactoryAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                {
                    lock (_loadLock)
                    {
                        if (_adapter == null)
                        {
                            _adapter = BuildLoggerFactoryAdapter();
                        }
                    }
                }
                return _adapter;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Adapter");
                }

                lock (_loadLock)
                {
                    _adapter = value;
                }
            }
        }


        /// <summary>
        /// Gets or sets the adapter.
        /// </summary>
        /// <value>The adapter.</value>
        ILoggerFactoryAdapter ILogManager.Adapter
        {
            get { return Adapter; }
            set { Adapter = value; }
        }

        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(Type)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified type.
        /// </summary>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
        public static ILog GetLogger<T>()
        {
            return Adapter.GetLogger(typeof(T));
        }

        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(Type)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified type.
        /// </summary>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
        ILog ILogManager.GetLogger<T>()
        {
            return GetLogger<T>();
        }


        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(Type)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
        public static ILog GetLogger(Type type)
        {
            return Adapter.GetLogger(type);
        }

        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(Type)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
        ILog ILogManager.GetLogger(Type type)
        {
            return GetLogger(type);
        }



        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(string)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
        public static ILog GetLogger(string key)
        {
            return Adapter.GetLogger(key);
        }

        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(string)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
        ILog ILogManager.GetLogger(string key)
        {
            return GetLogger(key);
        }


        /// <summary>
        /// Builds the logger factory adapter.
        /// </summary>
        /// <returns>a factory adapter instance. Is never <c>null</c>.</returns>
        private static ILoggerFactoryAdapter BuildLoggerFactoryAdapter()
        {
            
            // configuration reader returned <null>
            if (_type == null)
            {
                ILoggerFactoryAdapter defaultFactory = new NoOpLoggerFactoryAdapter();
                return defaultFactory;
            }

            ILoggerFactoryAdapter adapter = adapter = (ILoggerFactoryAdapter)Activator.CreateInstance(_type); 
            return adapter;
        }
        
    }
}