using System;
using System.Diagnostics;
using System.Reflection;

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

        public void LogWarning(string message)
        {
            var caller = GetCaller();

            var className = caller != null && caller.ReflectedType != null ? caller.ReflectedType.FullName : null;
            var functionName = caller != null ? caller.Name : null;

            var logEntry = new LogEntry
            {
                ClassName = className,
                FunctionName = functionName,
                Message = message,
                Severity = Severity.Warning
            };

            _logWriter.Write(logEntry);
        }

        public void LogInfo(string message)
        {
            var caller = GetCaller();

            var className = caller != null && caller.ReflectedType != null ? caller.ReflectedType.FullName : null;
            var functionName = caller != null ? caller.Name : null;

            var logEntry = new LogEntry
            {
                ClassName = className,
                FunctionName = functionName,
                Message = message,
                Severity = Severity.Info
            };

            _logWriter.Write(logEntry);
        }

        private MethodBase GetCaller()
        {
            var frame = new StackFrame(2);
            return frame.GetMethod();
        }
    }
}
