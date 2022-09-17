using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;


namespace Common.Logging;
public static class LoggingExtensions
{
    public static void AddLogger(this IServiceCollection service, IConfiguration configuration)
    {

        service.AddLogging(logger =>
        {
            logger.ClearProviders();
            logger.AddNLog();
        });

        service.AddSingleton<ILogger, NLogger>(logger => new NLogger(configuration));
    }
}