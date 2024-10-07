using MethodBoundaryAspect.Fody.Attributes;
using WarcraftApi.CrossCutting.Utils.Logger;

namespace WarcraftApi.CrossCutting.Aspects;

[Serializable]
public class LogAttribute : OnMethodBoundaryAspect
{
    private static readonly ILogger Logger = new Logger(nameof(LogAttribute));

    public override void OnEntry(MethodExecutionArgs args)
    {
        var className = args.Method.DeclaringType?.Name ?? "UnknownClass";
        var methodName = args.Method.Name;
        var parameters = string.Join(", ", args.Arguments);

        Logger.Info(string.Format(Resources.TimerAspectMessage, className, methodName, parameters));
    }

    public override void OnExit(MethodExecutionArgs args)
    {
        var className = args.Method.DeclaringType?.Name ?? "UnknownClass";
        var methodName = args.Method.Name;

        Logger.Info(string.Format(Resources.TimerAspectMessage, className, methodName));
    }
}