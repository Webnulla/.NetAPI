using System;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.Model;
using MetricsAgent.Requests;
using MetricsManager.Client;
using MetricsManager.Controllers;
using Quartz;

namespace MetricsManager.Jobs
{
    public class NetworkMetricsJob : IJob
    {
        private IMetricsAgentClient _metricsAgentClient;
        private IMapper _mapper;
        private INetworkMetricsRepository _networkMetricsRepository;

        public NetworkMetricsJob
        (
            IMetricsAgentClient metricsAgentClient, 
            IMapper mapper, 
            INetworkMetricsRepository networkMetricsRepository
        )        
        
        {
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
            _networkMetricsRepository = networkMetricsRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var response = _metricsAgentClient.GetAllNetworkMetrics(
                new MetricsCreateRequest<NetworkMetricsController>(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10)));
            foreach (var metricDto in response.Metrics)
            {
                var networkMetric = _mapper.Map<NetworkMetrics>(metricDto);
                _networkMetricsRepository.Create(networkMetric);
            }
            return Task.CompletedTask;
        }
    }
}