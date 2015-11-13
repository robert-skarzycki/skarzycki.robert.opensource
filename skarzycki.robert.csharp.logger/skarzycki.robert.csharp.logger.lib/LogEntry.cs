using System;

namespace skarzycki.robert.csharp.logger.lib
{
    public class LogEntry
    {
        public LogEntry()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
        public string Message { get; set; }
        public Severity Severity { get; set; }
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
    }
}
