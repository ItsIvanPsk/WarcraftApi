namespace WarcraftApi.CrossCutting.Utils.Logger;

public interface ILoggerService
{
    void LogDebug(string? message);
    void LogInformation(string? message);
    void LogWarning(string? message);
    void LogError(string? message, Exception? ex = null);
    void LogCritical(string? message, Exception? ex = null);
}
