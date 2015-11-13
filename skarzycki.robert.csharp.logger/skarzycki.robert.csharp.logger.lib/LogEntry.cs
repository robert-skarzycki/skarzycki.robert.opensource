using System;

namespace skarzycki.robert.csharp.logger.lib
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public Severity Severity { get; set; }
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
    }
}
