using Quartz;
using Quartz.Impl;

namespace CUGOJ.CUGOJ_Tools.CronJob;

public class QuartzProcessor : ICronJobProcesser
{
    private class TimeJob : IJob
    {

        public async Task Execute(IJobExecutionContext context)
        {
            var Action = context.JobDetail.JobDataMap.Get("Action") as Func<Task>;
            if (Action != null)
            {
                await Action();
            }
        }
    }
    private IScheduler? _scheduler;

    public async void Init()
    {
        var schedulerFactory = new StdSchedulerFactory();
        _scheduler = await schedulerFactory.GetScheduler();
        await _scheduler.Start();
    }

    public void AddJob(Func<Task> action, int repeatCount = 0, int repeatInterval = 0)
    {
        var job = JobBuilder.Create<TimeJob>()
        .SetJobData(new JobDataMap(){
            {"Action", action}
        })
        .Build();
        var trigger = TriggerBuilder.Create()
            .WithSimpleSchedule(x =>
            {
                x = x.WithIntervalInSeconds(repeatInterval);
                if (repeatCount > 0) x = x.WithRepeatCount(repeatCount);
                else x = x.RepeatForever();
            })
            .Build();
        _scheduler?.ScheduleJob(job, trigger);
    }

}