using MetricsAgent.DAL;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _networkPerformanceCounter;

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            _networkPerformanceCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var networkSpeed = Convert.ToInt32(_networkPerformanceCounter.NextValue());
            _repository.Create(new Model.NetworkMetrics
            {
                Value = networkSpeed
            });
            return Task.CompletedTask;
        }
    }
}
