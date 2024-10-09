using Serilog;

namespace WarcraftApi.CrossCutting.Utils.Logger
{
    public class Logger : ILoggerService
    {
        private readonly ILogger _logger = Log.Logger;

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogInformation(string? message)
        {
            _logger.Information(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warning(message);
        }

        public void LogError(string message, Exception? ex = null)
        {
            if (ex == null)
            {
                _logger.Error(message);
            }
            else
            {
                _logger.Error(ex, message);
            }
        }

        public void LogCritical(string message, Exception? ex = null)
        {
            if (ex == null)
            {
                _logger.Fatal(message);
            }
            else
            {
                _logger.Fatal(ex, message);
            }
        }
    }

}