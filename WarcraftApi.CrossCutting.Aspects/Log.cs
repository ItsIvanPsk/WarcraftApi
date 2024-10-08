using MethodBoundaryAspect.Fody.Attributes;
using WarcraftApi.CrossCutting.Utils.Logger;

namespace WarcraftApi.CrossCutting.Aspects
{
    [Serializable]
    public class LogAttribute : OnMethodBoundaryAspect
    {
        private ILogger<LogAttribute> GetLogger()
        {
            return new Logger<LogAttribute>();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var logger = GetLogger();
            var className = args.Method.DeclaringType?.Name ?? "UnknownClass";
            var methodName = args.Method.Name;
            var parameters = string.Join(", ", args.Arguments);

            logger.Info($"Entering {className}.{methodName} with parameters: {parameters}");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var logger = GetLogger();
            var className = args.Method.DeclaringType?.Name ?? "UnknownClass";
            var methodName = args.Method.Name;

            logger.Info($"Exiting {className}.{methodName}");
        }
    }
}