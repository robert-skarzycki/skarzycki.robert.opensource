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

        public void LogException()
        {
            throw new NotImplementedException();
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
