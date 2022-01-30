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
    public class CpuMetricsJob : IJob
    {
        private IMetricsAgentClient _metricsAgentClient;
        private IMapper _mapper;
        private ICpuMetricsRepository _cpuMetricsRepository;

        public CpuMetricsJob
        (
            IMetricsAgentClient metricsAgentClient, 
            IMapper mapper, 
            ICpuMetricsRepository cpuMetricsRepository
        )        
        
        {
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
            _cpuMetricsRepository = cpuMetricsRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var response = _metricsAgentClient.GetAllCpuMetrics(
                new MetricsCreateRequest<CpuMetricsController>(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10)));
            foreach (var metricDto in response.Metrics)
            {
                var cpuMetric = _mapper.Map<CpuMetrics>(metricDto);
                _cpuMetricsRepository.Create(cpuMetric);
            }
            return Task.CompletedTask;
        }
    }
}