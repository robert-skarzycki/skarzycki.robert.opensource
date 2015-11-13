using System;

namespace skarzycki.robert.csharp.logger.lib
{
    public class Logger
    {
        private readonly ILogWriter _logWriter;

        public Logger(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        public void LogException(Exception exception)
        {
            var targetSite = exception.TargetSite;
            
            var className = targetSite != null && targetSite.ReflectedType!=null ? targetSite.ReflectedType.FullName : null;
            var functionName = targetSite != null ? targetSite.Name : null;
            var message = exception.Message;

            var logEntry = new LogEntry
            {
                ClassName = className,
                FunctionName = functionName,
                Message = message,
                Severity = Severity.Error
            };

            _logWriter.Write(logEntry);
        }

        public void LogWarning()
        {
            throw new NotImplementedException();
        }

        public void LogInfo()
        {
            throw new NotImplementedException();
        }
    }
}
