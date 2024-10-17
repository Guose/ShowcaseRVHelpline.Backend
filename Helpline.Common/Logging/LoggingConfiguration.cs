using Serilog;
using Serilog.Events;

namespace Helpline.Common.Logging
{
    public class LoggingConfiguration
    {
        internal static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs/autitlog.txt", rollingInterval: RollingInterval.Month)
                .CreateLogger();
        }
    }
}
