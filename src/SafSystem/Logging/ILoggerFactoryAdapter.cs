using System;

namespace Ataoge.Logging
{
    ///<summary>
    /// The type of method that is passed into e.g. <see cref="ILog.Debug(System.Action{Common.Logging.FormatMessageHandler})"/> 
    /// and allows the callback method to "submit" it's message to the underlying output system.
    ///</summary>
    ///<param name="format">the format argument as in <see cref="string.Format(string,object[])"/></param>
    ///<param name="args">the argument list as in <see cref="string.Format(string,object[])"/></param>
    ///<seealso cref="ILog"/>
    /// <author>Erich Eichinger</author>
    public delegate string FormatMessageHandler(string format, params object[] args);

    /// <summary>
	/// LoggerFactoryAdapter interface is used internally by LogManager
	/// Only developers wishing to write new Common.Logging adapters need to
	/// worry about this interface.
	/// </summary>
	public interface ILoggerFactoryAdapter
    {

        /// <summary>
        /// Get a ILog instance by type.
        /// </summary>
        /// <param name="type">The type to use for the logger</param>
        /// <returns></returns>
		ILog GetLogger(Type type);

        /// <summary>
        /// Get a ILog instance by key.
        /// </summary>
        /// <param name="key">The key of the logger</param>
        /// <returns></returns>
		ILog GetLogger(string key);

    }
}