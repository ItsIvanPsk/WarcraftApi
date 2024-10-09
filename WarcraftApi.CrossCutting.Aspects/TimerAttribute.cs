using System.Diagnostics;
using MethodBoundaryAspect.Fody.Attributes;
using WarcraftApi.CrossCutting.Utils.Logger;

namespace WarcraftApi.CrossCutting.Aspects;

[Serializable]
public class TimerAttribute : OnMethodBoundaryAspect
{
    private Stopwatch _stopwatch;

    public override void OnEntry(MethodExecutionArgs args)
    {
        _stopwatch = Stopwatch.StartNew();
    }

    public override void OnExit(MethodExecutionArgs args)
    {
        _stopwatch.Stop();
        var logger = LoggerProvider.GetLogger();
        var className = args.Method.DeclaringType?.Name ?? "UnknownClass";
        var methodName = args.Method.Name;
        var elapsedTime = _stopwatch.ElapsedMilliseconds;
        logger?.LogInformation($"[Warcraft API] <=> Execution of {className}.{methodName} completed in {elapsedTime} ms");
    }
}