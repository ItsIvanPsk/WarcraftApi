using System.Reflection;
using log4net;
using log4net.Config;

namespace WarcraftApi.CrossCutting.Utils.Logger
{
    public class Logger<T> : ILogger<T>
    {
        private readonly ILog _logger;

        public Logger()
        {
            _logger = LogManager.GetLogger(typeof(T).FullName);
            ConfigureLog4Net();
        }

        private static void ConfigureLog4Net()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? throw new InvalidOperationException());
            var log4NetConfig = new FileInfo("log4net.config");

            if (log4NetConfig.Exists)
                XmlConfigurator.Configure(logRepository, log4NetConfig);
            else
                throw new FileNotFoundException("No se encontró el archivo log4net.config.");
        }

        public void Debug(string message)
        {
            if (_logger.IsDebugEnabled)
                _logger.Debug(message);
        }

        public void Info(string message)
        {
            if (_logger.IsInfoEnabled)
                _logger.Info(message);
        }

        public void Warn(string message)
        {
            if (_logger.IsWarnEnabled)
                _logger.Warn(message);
        }

        public void Error(string message)
        {
            if (_logger.IsErrorEnabled)
                _logger.Error(message);
        }

        public void Fatal(string message)
        {
            if (_logger.IsFatalEnabled)
                _logger.Fatal(message);
        }
    }
}