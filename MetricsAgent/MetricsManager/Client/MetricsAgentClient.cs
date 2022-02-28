using System;
using System.Net.Http;
using System.Security.AccessControl;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MetricsManager.Controllers;

namespace MetricsManager.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MetricsAgentClient> _logger;

        public MetricsAgentClient(HttpClient httpClient, ILogger<MetricsAgentClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public AllCpuMetricsResponse GetAllCpuMetrics(MetricsCreateRequest<CpuMetricsController> request)
        {
            var fromParameter = request.From.TotalSeconds;
            var toParameter = request.To.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"https://localhost:44371/api/metrics/cpu/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllCpuMetricsResponse>(responseStream).Result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return null;
        }

        public AllHddMetricsResponse GetAllHddMetrics(MetricsCreateRequest<HddMetricsController> request)
        {
            var fromParameter = request.From.TotalSeconds;
            var toParameter = request.To.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"https://localhost:44371/api/metrics/hdd/left/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllHddMetricsResponse>(responseStream).Result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return null;
        }

        public AllDotNetMetricsResponse GetAllDotNetMetrics(MetricsCreateRequest<DotNetMetricsController> request)
        {
            var fromParameter = request.From.TotalSeconds;
            var toParameter = request.To.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"https://localhost:44371/api/metrics/dotnet/errors-count/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllDotNetMetricsResponse>(responseStream).Result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return null;
        }

        public AllNetworkMetricsResponse GetAllNetworkMetrics(MetricsCreateRequest<NetworkMetricsController> request)
        {
            var fromParameter = request.From.TotalSeconds;
            var toParameter = request.To.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"https://localhost:44371/api/metrics/network/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllNetworkMetricsResponse>(responseStream).Result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return null;
        }

        public AllRamMetricsResponse GetAllRamMetrics(MetricsCreateRequest<RamMetricsController> request)
        {
            var fromParameter = request.From.TotalSeconds;
            var toParameter = request.To.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"https://localhost:44371/api/metrics/ram/available/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllRamMetricsResponse>(responseStream).Result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return null;
        }
    }
}