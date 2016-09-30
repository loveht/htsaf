using Ataoge.Logging;
using Ataoge.Logging.Simple;
using Microsoft.Extensions.Logging;

namespace Ataoge.Application
{
    public static class AppExtensions
    {
        public static IApp UseCoreLogging(this IApp app, ILoggerFactory loggerFactory)
        {
            LogManager.Adapter = new CoreLoggerFactoryAdapter(loggerFactory);
            return app;
        } 
    }
}