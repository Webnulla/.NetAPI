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
        }

        public Task Execute(IJobExecutionContext context)
        {
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");

            String[] adapterName = category.GetInstanceNames();

            int networkSpeed = 0;

            foreach (var item in adapterName)
            {
                _networkPerformanceCounter = new PerformanceCounter
                (
                    "Network Interface",
                    "Bytes Received/sec",
                    item
                );

                networkSpeed += Convert.ToInt32(_networkPerformanceCounter.NextValue());
            }

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new Model.NetworkMetrics
            {
                Value = networkSpeed,
                Time = time
            });
            return Task.CompletedTask;
        }
    }
}