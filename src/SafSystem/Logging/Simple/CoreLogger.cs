using System;
using Microsoft.Extensions.Logging;

namespace Ataoge.Logging.Simple
{
    public class CoreLogger : ILog
    {
        public CoreLogger(ILogger logger)
        {
            this.innerLogger = logger;
            this.defaultEventId = new EventId();
        }

        private EventId defaultEventId;
        public EventId DefaultEventId
        {
            get {return this.defaultEventId;}
        }

        private Microsoft.Extensions.Logging.ILogger innerLogger;

        public IVariablesContext GlobalVariablesContext
        {
            get
            {
                return new NoOpVariablesContext();
            }
        }

        public bool IsDebugEnabled
        {
            get
            {
                return innerLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Debug);
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return innerLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Error);
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return innerLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Critical);
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return innerLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Information);
            }
        }

        public bool IsTraceEnabled
        {
            get
            {
                return innerLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace);
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return innerLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Warning);
            }
        }

        public IVariablesContext ThreadVariablesContext
        {
            get
            {
                return new NoOpVariablesContext();
            }
        }

        
        public void Debug(Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsDebugEnabled)
            {
                innerLogger.LogDebug(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Debug(object message)
        {
            if (IsDebugEnabled)
            {
                innerLogger.LogDebug(this.DefaultEventId, null, message.ToString());
            }
        }

        public void Debug(Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            if (IsDebugEnabled)
            {
                innerLogger.LogDebug(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Debug(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsDebugEnabled)
            {
                innerLogger.LogDebug(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider, formatMessageCallback).ToString());
            }
        }

        public void Debug(object message, Exception exception)
        {
            if (IsDebugEnabled)
            {
                innerLogger.LogDebug(this.DefaultEventId, exception, message.ToString());
            }
        }

        public void Debug(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            if (IsDebugEnabled)
            {
                innerLogger.LogDebug(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider, formatMessageCallback).ToString());
            }
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (IsDebugEnabled)
            {
                innerLogger.LogDebug(this.DefaultEventId, null, format, args);
            }
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsDebugEnabled)
            {
                innerLogger.LogDebug(this.DefaultEventId, null, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void DebugFormat(string format, Exception exception, params object[] args)
        {
           if (IsDebugEnabled)
            {
                innerLogger.LogDebug(this.DefaultEventId, exception, format, args);
            }
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsDebugEnabled)
            {
                innerLogger.LogDebug(this.DefaultEventId, exception, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void Error(Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsErrorEnabled)
            {
                innerLogger.LogError(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Error(object message)
        {
            if (IsErrorEnabled)
            {
                innerLogger.LogError(this.DefaultEventId, null, message.ToString());
            }
        }

        public void Error(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsErrorEnabled)
            {
                innerLogger.LogError(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider,formatMessageCallback).ToString());
            }
        }

        public void Error(Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            if (IsErrorEnabled)
            {
                innerLogger.LogError(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Error(object message, Exception exception)
        {
            if (IsErrorEnabled)
            {
                innerLogger.LogError(this.DefaultEventId, exception, message.ToString());
            }
        }

        public void Error(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            if (IsErrorEnabled)
            {
                innerLogger.LogError(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider,formatMessageCallback).ToString());
            }
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (IsErrorEnabled)
            {
                innerLogger.LogError(this.DefaultEventId, null, format, args);
            }
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsErrorEnabled)
            {
                innerLogger.LogError(this.DefaultEventId, null, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void ErrorFormat(string format, Exception exception, params object[] args)
        {
            if (IsErrorEnabled)
            {
                innerLogger.LogError(this.DefaultEventId, exception, format, args);
            }
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsErrorEnabled)
            {
                innerLogger.LogError(this.DefaultEventId, exception, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void Fatal(Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsFatalEnabled)
            {
                innerLogger.LogCritical(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Fatal(object message)
        {
            if (IsFatalEnabled)
            {
                innerLogger.LogCritical(this.DefaultEventId, null, message.ToString());
            }
        }

        public void Fatal(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsFatalEnabled)
            {
                innerLogger.LogCritical(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider,formatMessageCallback).ToString());
            }
        }

        public void Fatal(Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            if (IsFatalEnabled)
            {
                innerLogger.LogCritical(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Fatal(object message, Exception exception)
        {
            if (IsFatalEnabled)
            {
                innerLogger.LogCritical(this.DefaultEventId, exception, message.ToString());
            }
        }

        public void Fatal(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
             if (IsFatalEnabled)
            {
                innerLogger.LogCritical(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider,formatMessageCallback).ToString());
            }
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (IsFatalEnabled)
            {
                innerLogger.LogCritical(this.DefaultEventId, null, format, args);
            }
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsFatalEnabled)
            {
                innerLogger.LogCritical(this.DefaultEventId, null, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void FatalFormat(string format, Exception exception, params object[] args)
        {
            if (IsFatalEnabled)
            {
                innerLogger.LogCritical(this.DefaultEventId, exception, format, args);
            }
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsFatalEnabled)
            {
                innerLogger.LogCritical(this.DefaultEventId, exception, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void Info(Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsInfoEnabled)
            {
                innerLogger.LogInformation(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Info(object message)
        {
            if (IsInfoEnabled)
            {
                innerLogger.LogInformation(this.DefaultEventId, null, message.ToString());
            }
        }

        public void Info(Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            if (IsInfoEnabled)
            {
                innerLogger.LogInformation(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Info(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsInfoEnabled)
            {
                innerLogger.LogInformation(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider,formatMessageCallback).ToString());
            }
        }

        public void Info(object message, Exception exception)
        {
            if (IsInfoEnabled)
            {
                innerLogger.LogInformation(this.DefaultEventId, exception, message.ToString());
            }
        }

        public void Info(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            if (IsInfoEnabled)
            {
                innerLogger.LogInformation(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider,formatMessageCallback).ToString());
            }
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (IsInfoEnabled)
            {
                innerLogger.LogInformation(this.DefaultEventId, null, format, args);
            }
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsInfoEnabled)
            {
                innerLogger.LogInformation(this.DefaultEventId, null, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void InfoFormat(string format, Exception exception, params object[] args)
        {
            if (IsInfoEnabled)
            {
                innerLogger.LogInformation(this.DefaultEventId, exception, format, args);
            }
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsInfoEnabled)
            {
                innerLogger.LogInformation(this.DefaultEventId, exception, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void Trace(Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsTraceEnabled)
            {
                innerLogger.LogTrace(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Trace(object message)
        {
            if (IsTraceEnabled)
            {
                innerLogger.LogTrace(this.DefaultEventId, null, message.ToString());
            }
        }

        public void Trace(Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            if (IsTraceEnabled)
            {
                innerLogger.LogTrace(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Trace(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsTraceEnabled)
            {
                innerLogger.LogTrace(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider,formatMessageCallback).ToString());
            }
        }

        public void Trace(object message, Exception exception)
        {
            if (IsTraceEnabled)
            {
                innerLogger.LogTrace(this.DefaultEventId, exception, message.ToString());
            }
        }

        public void Trace(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
             if (IsTraceEnabled)
            {
                innerLogger.LogTrace(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider,formatMessageCallback).ToString());
            }
        }

        public void TraceFormat(string format, params object[] args)
        {
            if (IsTraceEnabled)
            {
                innerLogger.LogTrace(this.DefaultEventId, null, format, args);
            }
        }

        public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsTraceEnabled)
            {
                innerLogger.LogTrace(this.DefaultEventId, null, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void TraceFormat(string format, Exception exception, params object[] args)
        {
            if (IsTraceEnabled)
            {
                innerLogger.LogTrace(this.DefaultEventId, exception, format, args);
            }
        }

        public void TraceFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsTraceEnabled)
            {
                innerLogger.LogTrace(this.DefaultEventId, exception, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void Warn(Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsWarnEnabled)
            {
                innerLogger.LogWarning(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Warn(object message)
        {
            if (IsWarnEnabled)
            {
                innerLogger.LogWarning(this.DefaultEventId, null, message.ToString());
            }
        }

        public void Warn(Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            if (IsWarnEnabled)
            {
                innerLogger.LogWarning(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatMessageCallback).ToString());
            }
        }

        public void Warn(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            if (IsWarnEnabled)
            {
                innerLogger.LogWarning(this.DefaultEventId, null, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider,formatMessageCallback).ToString());
            }
        }

        public void Warn(object message, Exception exception)
        {
            if (IsWarnEnabled)
            {
                innerLogger.LogWarning(this.DefaultEventId, exception, message.ToString());
            }
        }

        public void Warn(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            if (IsWarnEnabled)
            {
                innerLogger.LogWarning(this.DefaultEventId, exception, new AbstractLogger.FormatMessageCallbackFormattedMessage(formatProvider,formatMessageCallback).ToString());
            }
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (IsWarnEnabled)
            {
                innerLogger.LogWarning(this.DefaultEventId, null, format, args);
            }
        }

        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsWarnEnabled)
            {
                innerLogger.LogWarning(this.DefaultEventId, null, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }

        public void WarnFormat(string format, Exception exception, params object[] args)
        {
            if (IsWarnEnabled)
            {
                innerLogger.LogWarning(this.DefaultEventId, exception, format, args);
            }
        }

        public void WarnFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsWarnEnabled)
            {
                innerLogger.LogWarning(this.DefaultEventId, exception, new AbstractLogger.StringFormatFormattedMessage(formatProvider, format, args).ToString());
            }
        }
    }
}