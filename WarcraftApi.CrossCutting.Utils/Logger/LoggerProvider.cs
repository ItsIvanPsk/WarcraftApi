namespace WarcraftApi.CrossCutting.Utils.Logger;

public static class LoggerProvider
{
    private static ILoggerService? _loggerService;

    public static void SetLogger(ILoggerService? loggerService)
    {
        _loggerService = loggerService;
    }

    public static ILoggerService? GetLogger()
    {
        if (_loggerService == null)
        {
            throw new InvalidOperationException("LoggerService is not initialized.");
        }

        return _loggerService;
    }
}
