using System;

namespace Microsoft.Extensions.Logging
{
    public static class SafLoggerExtensions
    {
        public static ILoggerFactory AddEmail(this ILoggerFactory factory, Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new Ataoge.Logging.SafLoggerProvider(filter));
            return factory;
        }

        public static ILoggerFactory AddEmail(this ILoggerFactory factory, LogLevel minLevel)
        {
            return AddEmail(factory, (text, logLevel) => logLevel >= minLevel);
        }
    }
}