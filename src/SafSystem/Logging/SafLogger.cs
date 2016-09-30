using System;
using Microsoft.Extensions.Logging;

namespace Ataoge.Logging
{
    public class SafLogger : Microsoft.Extensions.Logging.ILogger
    {
        private string categoryName;
        private Func<string, Microsoft.Extensions.Logging.LogLevel, bool> filter;

        public SafLogger(string categoryName, Func<string, Microsoft.Extensions.Logging.LogLevel, bool> filter) {
            this.categoryName = categoryName;
            this.filter = filter;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            return (filter == null || filter(categoryName, logLevel));
        }

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
 
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
 
            var message = formatter(state, exception);
    
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
 
            message = $"{ logLevel }: {message}";
    
            if (exception != null)
            {
                message += Environment.NewLine + Environment.NewLine + exception.ToString();
            }
 
        }
    }
}