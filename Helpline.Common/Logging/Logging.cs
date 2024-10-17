
using Helpline.Common.Interfaces;
using Serilog;

namespace Helpline.Common.Logging
{
    public class Logging : ILogging
    {
        static Logging()
        {
            LoggingConfiguration.ConfigureLogger();
        }
        public void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }

        public void LogAudit(string action, int userId, string details, params object[] args)
        {
            Log.Information("Audit: Action={Action}, UserId={UserId}, Details={Details}", action, userId, details, args);
        }

        public void LogError(string message, params object[] args)
        {
            Log.Error(message, args);
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            Log.Error(exception, message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            Log.Information(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            Log.Warning(message, args);
        }
    }
}
