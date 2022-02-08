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
    public class DotNetMetricsJob : IJob
    {
        private IMetricsAgentClient _metricsAgentClient;
        private IMapper _mapper;
        private IDotNetMetricsReposiroty _dotNetMetricsReposiroty;

        public DotNetMetricsJob
        (
            IMetricsAgentClient metricsAgentClient,
            IMapper mapper,
            IDotNetMetricsReposiroty dotNetMetricsReposiroty
        )

        {
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
            _dotNetMetricsReposiroty = dotNetMetricsReposiroty;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var response = _metricsAgentClient.GetAllDotNetMetrics(
                new MetricsCreateRequest<DotNetMetricsController>(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10)));
            foreach (var metricDto in response.Metrics)
            {
                var dotNetMetric = _mapper.Map<DotNetMetrics>(metricDto);
                _dotNetMetricsReposiroty.Create(dotNetMetric);
            }

            return Task.CompletedTask;
        }
    }
}