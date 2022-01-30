using MetricsAgent.DAL;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _repository;
        private PerformanceCounter _hddPerformanceCounter;

        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;
            _hddPerformanceCounter = new PerformanceCounter
            (
                "Memory",
                "Available MBytes"
            );
        }

        public Task Execute(IJobExecutionContext context)
        {
            var hddMemory = Convert.ToInt32(_hddPerformanceCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new Model.HddMetrics
            {
                Value = hddMemory,
                Time = time
            });
            return Task.CompletedTask;
        }
    }
}