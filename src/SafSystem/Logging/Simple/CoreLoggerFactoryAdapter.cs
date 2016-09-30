using System;
using Microsoft.Extensions.Logging;

namespace Ataoge.Logging.Simple
{
    public class CoreLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
        public CoreLoggerFactoryAdapter(ILoggerFactory loggerFactory)
        {
            this._loggerFactory = loggerFactory;
        }

        private ILoggerFactory _loggerFactory; 

        public ILog GetLogger(string key)
        {
            ILogger logger =  _loggerFactory.CreateLogger(key);
            return new CoreLogger(logger);
        }

        public ILog GetLogger(Type type)
        {
            ILogger logger =  _loggerFactory.CreateLogger(type.FullName);
            return new CoreLogger(logger);
        }
    }
}