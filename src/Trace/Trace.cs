using Castle.Core;
using Castle.DynamicProxy;
using System.Diagnostics;
using System.Collections.Concurrent;
namespace CUGOJ.CUGOJ_Tools.Trace
{
    public class LogStruct
    {
        public enum LogLevel
        {
            Info,
            Warning,
            Error,
            IO
        }
        public string Content = string.Empty;
        public DateTime Time = DateTime.Now;
        public string IP = TraceManager.IP;
        public string Port = TraceManager.Port;
        public string PodName = TraceManager.PodName;
        public string FileLineInfo = string.Empty;
        public LogLevel Level = LogLevel.Info;
    }
    public class TraceNode
    {
        public enum TraceStatus
        {
            Success,
            Failed
        }
        public string Id = string.Empty;
        public string ParentId = string.Empty;
        public ConcurrentBag<LogStruct> Logs = new();
        public string DisplayName = string.Empty;
        public DateTime StartTime = DateTime.Now;
        public TimeSpan Duration;
        public ConcurrentBag<TraceNode> ChildNodes = new();
        public TraceStatus Status = TraceStatus.Success;
        public string IP = TraceManager.IP;
        public string Port = TraceManager.Port;
        public string PodName = TraceManager.PodName;
    }

}