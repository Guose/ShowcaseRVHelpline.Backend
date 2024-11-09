using Serilog;
using Serilog.Events;

namespace Helpline.Common.Logging
{
    public class LoggingConfiguration
    {
        public static void ConfigureLogger()
        {
            // Logging configuration. Once application is further along, switch internal to weekly
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("./Logs/helplinelogs.txt", rollingInterval: RollingInterval.Month)
                .CreateLogger();
        }
    }
}
