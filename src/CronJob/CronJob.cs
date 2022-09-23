namespace CUGOJ.CUGOJ_Tools.CronJob;

public static class CronJob
{
    private static ICronJobProcesser? _processer;
    private static object _initLock = new();
    private static int _initCount = 0;
    public static void Init()
    {
        if (_initCount != 0) return;
        lock (_initLock)
        {
            if (_initCount != 0) return;
            _initCount++;
            _processer = new QuartzProcessor();
            _processer.Init();
        }
    }
    public static void AddJob(Func<Task> action, int repeatCount = 0, int repeatInterval = 5)
    {
        if (_processer == null)
            throw new Exception("调度器未初始化");
        _processer.AddJob(action, repeatCount, repeatInterval);
    }
}

public interface ICronJobProcesser
{
    void Init();
    void AddJob(Func<Task> action, int repeatCount = 0, int repeatInterval = 5);
}