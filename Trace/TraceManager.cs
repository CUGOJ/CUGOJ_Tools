using Castle.Core;
using Castle.DynamicProxy;
using System.Net;
using System.Diagnostics;
using System.Collections.Concurrent;
namespace CUGOJ.CUGOJ_Tools.Trace
{
    public static class TraceManager
    {
        private static object _onceLock = new object();
        private static int _onceLockCounter = 0;
        public static void InitTraceManager(string port, string podName)
        {
            lock (_onceLock)
            {
                Interlocked.Increment(ref _onceLockCounter);
                foreach (var ipAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                    if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                        _ip = ipAddress.ToString();
                _port = port;
                _podName = podName;
            }
        }
        public static bool Debug = false;
        private static string _ip = string.Empty;
        public static string IP
        {
            get => _ip;
        }
        private static string _port = string.Empty;
        public static string Port
        {
            get => _port;
        }
        private static string _podName = string.Empty;
        public static string PodName
        {
            get => _podName;
        }
        public static ConcurrentDictionary<string, TraceNode> TraceNodes = new();
        public static void AddTraceNode(TraceNode node)
        {
            var parent = TraceNodes[node.ParentId];
            if (parent != null)
            {
                parent.ChildNodes.Add(node);
            }
            TraceNodes.TryAdd(node.Id, node);
        }
        public static void RemoveTraceNode(string ActivityId)
        {
            TraceNode? outPut;
            TraceNodes.TryRemove(ActivityId, out outPut);
        }
        public static void AddLogStruct(string ActivityId, LogStruct log)
        {
            var node = TraceNodes[ActivityId];
            if (node != null)
            {
                node.Logs.Add(log);
            }
        }
    }
}