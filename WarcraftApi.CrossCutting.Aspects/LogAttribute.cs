using MethodBoundaryAspect.Fody.Attributes;
using WarcraftApi.CrossCutting.Utils.Logger;

namespace WarcraftApi.CrossCutting.Aspects
{
    [Serializable]
    public class LogAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {

            var logger = LoggerProvider.GetLogger();
            if (logger == null) 
                return;
            var className = args.Method.DeclaringType?.Name ?? "UnknownClass";
            var methodName = args.Method.Name;
            var parameters = string.Join(", ", args.Arguments);

            logger.LogInformation($"[Warcraft API] <=> Entering {className}.{methodName} with parameters: {parameters}");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var logger = LoggerProvider.GetLogger();
            if (logger == null) 
                return;
            var className = args.Method.DeclaringType?.Name ?? "UnknownClass";
            var methodName = args.Method.Name;

            logger.LogInformation($"[Warcraft API] <=> Exiting {className}.{methodName}");
        }

    }

}