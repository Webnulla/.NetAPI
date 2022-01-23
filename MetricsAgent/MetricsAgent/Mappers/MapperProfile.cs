using AutoMapper;
using MetricsAgent.Model;
using MetricsAgent.Responses;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetrics, CpuMetricsDto>();
            CreateMap<HddMetrics, HddMetricsDto>();
            CreateMap<RamMetrics, RamMetricsDto>();
            CreateMap<NetworkMetrics, NetworkMetricsDto>();
            CreateMap<DotNetMetrics, DotNetMetricsDto>();
        }
    }
}
