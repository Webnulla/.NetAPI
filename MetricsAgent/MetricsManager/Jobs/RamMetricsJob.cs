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
    public class RamMetricsJob : IJob
    {
        private IMetricsAgentClient _metricsAgentClient;
        private IMapper _mapper;
        private IRamMetricsRepository _ramMetricsRepository;

        public RamMetricsJob
        (
            IMetricsAgentClient metricsAgentClient, 
            IMapper mapper, 
            IRamMetricsRepository ramMetricsRepository
        )        
        
        {
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
            _ramMetricsRepository = ramMetricsRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var response = _metricsAgentClient.GetAllRamMetrics(
                new MetricsCreateRequest<RamMetricsController>(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10)));
            foreach (var metricDto in response.Metrics)
            {
                var ramMetric = _mapper.Map<RamMetrics>(metricDto);
                _ramMetricsRepository.Create(ramMetric);
            }
            return Task.CompletedTask;
        }
    }
}