using MetricsAgent.DAL;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricsReposiroty _repository;
        private PerformanceCounter _dotnetPerformanceCounter;

        public DotNetMetricJob(IDotNetMetricsReposiroty repository)
        {
            _repository = repository;
            _dotnetPerformanceCounter = new PerformanceCounter
            (
                ".NET CLR Memory",
                "% Time in GC",
                "_Global_"
            );
        }

        public Task Execute(IJobExecutionContext context)
        {
            var dotNetMemory = Convert.ToInt32(_dotnetPerformanceCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new Model.DotNetMetrics
            {
                Time = time,
                Value = dotNetMemory
            });
            return Task.CompletedTask;
        }
    }
}