using MetricsAgent.DAL;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class RamMetricJob : IJob
    {
        private IRamMetricsRepository _repository;
        private PerformanceCounter _ramPerformanceCounter;

        public RamMetricJob(IRamMetricsRepository repository)
        {
            _repository = repository;
            _ramPerformanceCounter = new PerformanceCounter
            (
                "Memory",
                "Available MBytes"
            );
        }

        public Task Execute(IJobExecutionContext context)
        {
            var ramValue = Convert.ToInt32(_ramPerformanceCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new Model.RamMetrics
            {
                Value = (int) ramValue,
                Time = time
            });
            return Task.CompletedTask;
        }
    }
}