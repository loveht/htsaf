using System;
using Microsoft.Extensions.Logging;

namespace Ataoge.Logging
{
    public class SafLoggerProvider : Microsoft.Extensions.Logging.ILoggerProvider
    {

        public SafLoggerProvider(Func<string, Microsoft.Extensions.Logging.LogLevel, bool> filter)
        {
            this.filter = filter;
        }
        private readonly Func<string, Microsoft.Extensions.Logging.LogLevel, bool> filter;

        public ILogger CreateLogger(string categoryName)
        {
            return new SafLogger(categoryName, this.filter);
        }

        public void Dispose()
        {
            
        }
    }
}