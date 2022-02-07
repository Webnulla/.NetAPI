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
    public class HddMetricsJob : IJob
    {
        private IMetricsAgentClient _metricsAgentClient;
        private IMapper _mapper;
        private IHddMetricsRepository _hddMetricsRepository;

        public HddMetricsJob
        (
            IMetricsAgentClient metricsAgentClient,
            IMapper mapper,
            IHddMetricsRepository hddMetricsRepository
        )

        {
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
            _hddMetricsRepository = hddMetricsRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var response = _metricsAgentClient.GetAllHddMetrics(
                new MetricsCreateRequest<HddMetricsController>(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10)));
            foreach (var metricDto in response.Metrics)
            {
                var hddMetric = _mapper.Map<HddMetrics>(metricDto);
                _hddMetricsRepository.Create(hddMetric);
            }

            return Task.CompletedTask;
        }
    }
}