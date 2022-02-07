using MetricsAgent.Requests;
using MetricsAgent.Responses;
using MetricsManager.Controllers;

namespace MetricsManager.Client
{
    public interface IMetricsAgentClient
    {
        AllCpuMetricsResponse GetAllCpuMetrics(MetricsCreateRequest<CpuMetricsController> request);
        AllRamMetricsResponse GetAllRamMetrics(MetricsCreateRequest<RamMetricsController> request);
        AllHddMetricsResponse GetAllHddMetrics(MetricsCreateRequest<HddMetricsController> request);
        AllNetworkMetricsResponse GetAllNetworkMetrics(MetricsCreateRequest<NetworkMetricsController> request);
        AllDotNetMetricsResponse GetAllDotNetMetrics(MetricsCreateRequest<DotNetMetricsController> request);
    }
}