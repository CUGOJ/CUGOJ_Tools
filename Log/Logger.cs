using System.Diagnostics;
using Serilog;
using Serilog.Context;
using System.IO;
using Serilog.Sinks.Loki;
namespace CUGOJ.CUGOJ_Tools.Log
{
    public static class Logger
    {

        private static object _onceLock = new object();
        private static int _onceLockCounter = 0;
        public static void InitLogger(string? LogAddress)
        {
            lock (_onceLock)
            {
                if (LogAddress != null)
                {
                    _logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .Enrich.FromLogContext()
                    .WriteTo.LokiHttp(new NoAuthCredentials(LogAddress), new LogLabelProvider())
                    .WriteTo.Console()
                    .CreateLogger();
                }
                else
                {
                    _logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                    .WriteTo.Console()
                    .CreateLogger();
                }
            }
        }
        private static ILogger? _logger;
        public static void Info(string template, params object?[] objects)
        {
            string methodName = string.Empty;
            string filePos = string.Empty;
            string traceID = string.Empty;
            StackTrace trace = new StackTrace();
            var frame = trace.GetFrame(1);

            if (frame != null)
            {
                var method = frame.GetMethod();
                if (method != null)
                    methodName = method.Name;
                var file = frame.GetFileName();
                var line = frame.GetFileLineNumber();
                if (file != null)
                    filePos = file + ":" + line;
            }

            using (var activity = Activity.Current)
            {
                if (activity != null)
                {
                    traceID = activity.TraceId.ToHexString();
                }
            }

            using (LogContext.PushProperty("Method", methodName))
            using (LogContext.PushProperty("FilePos", filePos))
            {
                if (traceID != string.Empty)
                {
                    using (LogContext.PushProperty("TraceID", traceID))
                        _logger?.Information(template, objects);
                }
                else
                    _logger?.Information(template, objects);
            }
        }

        public static void Warn(string template, params object?[] objects)
        {
            string methodName = string.Empty;
            string filePos = string.Empty;
            string traceID = string.Empty;
            StackTrace trace = new StackTrace();
            var frame = trace.GetFrame(1);

            if (frame != null)
            {
                var method = frame.GetMethod();
                if (method != null)
                    methodName = method.Name;
                var file = frame.GetFileName();
                var line = frame.GetFileLineNumber();
                if (file != null)
                    filePos = file + ":" + line;
            }

            using (var activity = Activity.Current)
            {
                if (activity != null)
                {
                    traceID = activity.TraceId.ToHexString();
                }
            }

            using (LogContext.PushProperty("Method", methodName))
            using (LogContext.PushProperty("FilePos", filePos))
            {
                if (traceID != string.Empty)
                {
                    using (LogContext.PushProperty("TraceID", traceID))
                        _logger?.Warning(template, objects);
                }
                else
                    _logger?.Warning(template, objects);
            }
        }

        public static void Error(string template, params object?[] objects)
        {
            string methodName = string.Empty;
            string filePos = string.Empty;
            string traceID = string.Empty;
            StackTrace trace = new StackTrace();
            var frame = trace.GetFrame(1);

            if (frame != null)
            {
                var method = frame.GetMethod();
                if (method != null)
                    methodName = method.Name;
                var file = frame.GetFileName();
                var line = frame.GetFileLineNumber();
                if (file != null)
                    filePos = file + ":" + line;
            }

            using (var activity = Activity.Current)
            {
                if (activity != null)
                {
                    traceID = activity.TraceId.ToHexString();
                }
            }

            using (LogContext.PushProperty("Method", methodName))
            using (LogContext.PushProperty("FilePos", filePos))
            {
                if (traceID != string.Empty)
                {
                    using (LogContext.PushProperty("TraceID", traceID))
                        _logger?.Error(template, objects);
                }
                else
                    _logger?.Error(template, objects);
            }
        }

        public static void Debug(string template, params object[] objects)
        {
            string methodName = string.Empty;
            string filePos = string.Empty;
            string traceID = string.Empty;
            StackTrace trace = new StackTrace();
            var frame = trace.GetFrame(1);

            if (frame != null)
            {
                var method = frame.GetMethod();
                if (method != null)
                    methodName = method.Name;
                var file = frame.GetFileName();
                var line = frame.GetFileLineNumber();
                if (file != null)
                    filePos = file + ":" + line;
            }

            using (var activity = Activity.Current)
            {
                if (activity != null)
                {
                    traceID = activity.TraceId.ToHexString();
                }
            }

            using (LogContext.PushProperty("Method", methodName))
            using (LogContext.PushProperty("FilePos", filePos))
            {
                if (traceID != string.Empty)
                {
                    using (LogContext.PushProperty("TraceID", traceID))
                        _logger?.Debug(template, objects);
                }
                else
                    _logger?.Debug(template, objects);
            }
        }
    }
}