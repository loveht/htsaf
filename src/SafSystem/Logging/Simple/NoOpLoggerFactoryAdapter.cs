using System;

namespace Ataoge.Logging.Simple
{
    /// <summary>
    /// Factory for creating <see cref="ILog" /> instances that silently ignores
    /// logging requests.
    /// </summary>
    /// <remarks>
    /// This logger adapter is the default used by Common.Logging if unconfigured. Using this logger adapter is the most efficient
    /// way to suppress any logging output.
    /// <example>
    /// Below is an example how to configure this adapter:
    /// <code>
    /// &lt;configuration&gt;
    /// 
    ///   &lt;configSections&gt;
    ///     &lt;sectionGroup key=&quot;common&quot;&gt;
    ///       &lt;section key=&quot;logging&quot;
    ///                type=&quot;Common.Logging.ConfigurationSectionHandler, Common.Logging&quot;
    ///                requirePermission=&quot;false&quot; /&gt;
    ///     &lt;/sectionGroup&gt;
    ///   &lt;/configSections&gt;
    /// 
    ///   &lt;common&gt;
    ///     &lt;logging&gt;
    ///       &lt;factoryAdapter type=&quot;Common.Logging.Simple.NoOpLoggerFactoryAdapter, Common.Logging&quot;&gt;
    ///         &lt;arg key=&quot;level&quot; value=&quot;ALL&quot; /&gt;
    ///       &lt;/factoryAdapter&gt;
    ///     &lt;/logging&gt;
    ///   &lt;/common&gt;
    /// 
    /// &lt;/configuration&gt;
    /// </code>
    /// </example>
    /// </remarks>
    /// <author>Gilles Bayon</author>
    public sealed class NoOpLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
        private static readonly ILog s_nopLogger = new NoOpLogger();

        /// <summary>
        /// Constructor
        /// </summary>
        public NoOpLoggerFactoryAdapter()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        //public NoOpLoggerFactoryAdapter(NameValueCollection properties)
        //{ }

        #region ILoggerFactoryAdapter Members

        /// <summary>
        /// Get a ILog instance by type 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILog GetLogger(Type type)
        {
            return s_nopLogger;
        }

        /// <summary>
        /// Get a ILog instance by type key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ILog ILoggerFactoryAdapter.GetLogger(string key)
        {
            return s_nopLogger;

        }

        #endregion
    }
}
