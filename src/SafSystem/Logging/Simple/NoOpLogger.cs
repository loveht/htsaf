using System;
using FormatMessageCallback = System.Action<Ataoge.Logging.FormatMessageHandler>;

namespace Ataoge.Logging.Simple
{
    public sealed class NoOpLogger : ILog
    {
        #region IsXXXEnabled

        /// <summary>
        /// Always returns <see langword="false" />.
        /// </summary>
        public bool IsTraceEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Always returns <see langword="false" />.
        /// </summary>
        public bool IsDebugEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Always returns <see langword="false" />.
        /// </summary>
        public bool IsInfoEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Always returns <see langword="false" />.
        /// </summary>
        public bool IsWarnEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Always returns <see langword="false" />.
        /// </summary>
        public bool IsErrorEnabled
        {
            get { return false; }

        }

        /// <summary>
        /// Always returns <see langword="false" />.
        /// </summary>
        public bool IsFatalEnabled
        {
            get { return false; }
        }

        #endregion

        #region Trace

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        public void Trace(object message)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public void Trace(object message, Exception e)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void TraceFormat(string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void TraceFormat(string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of message format arguments</param>
        public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void TraceFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Trace(FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        public void Trace(FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Trace(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        public void Trace(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        #endregion

        #region Debug

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public void Debug(object message, Exception e)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void DebugFormat(string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of message format arguments</param>
        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void DebugFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Debug(FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Debug.</param>
        public void Debug(FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Debug(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Debug.</param>
        public void Debug(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        #endregion

        #region Info

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public void Info(object message, Exception e)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void InfoFormat(string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of message format arguments</param>
        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void InfoFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Info(FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Info.</param>
        public void Info(FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Info(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Info.</param>
        public void Info(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        #endregion

        #region Warn

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public void Warn(object message, Exception e)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void WarnFormat(string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Warnrmation.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of message format arguments</param>
        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Warnrmation.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void WarnFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Warn(FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Warn.</param>
        public void Warn(FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Warn(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Warn.</param>
        public void Warn(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        #endregion

        #region Error

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public void Error(object message, Exception e)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void ErrorFormat(string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Errorrmation.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of message format arguments</param>
        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Errorrmation.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void ErrorFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Error(FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Error.</param>
        public void Error(FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Error(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Error.</param>
        public void Error(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        #endregion

        #region Fatal

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public void Fatal(object message, Exception e)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void FatalFormat(string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void FatalFormat(string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of message format arguments</param>
        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of message format arguments</param>
        public void FatalFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Fatal(FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Fatal.</param>
        public void Fatal(FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        public void Fatal(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Ignores message.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Fatal.</param>
        public void Fatal(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback, Exception exception)
        {
            // NOP - no operation
        }

        #endregion

        /// <summary>
        /// Returns the global context for variables
        /// </summary>
        public IVariablesContext GlobalVariablesContext
        {
            get { return new NoOpVariablesContext(); }
        }

        /// <summary>
        /// Returns the thread-specific context for variables
        /// </summary>
        public IVariablesContext ThreadVariablesContext
        {
            get { return new NoOpVariablesContext(); }
        }
    }
}
