using MetricsAgent.Controllers;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsServiceUi.Client
{
    public class ManagerUi
    {
        private readonly string _client = "https://localhost:44304";

        public AllCpuMetricsResponse GetCpuMetrics(MetricsCreateRequest<CpuMetricsController> request)
        {
            HttpClient httpClient = new HttpClient();
            var fromParameter = request.From.TotalSeconds;
            var toParameter = request.To.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{_client}/api/metrics/cpu/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllCpuMetricsResponse>(responseStream).Result;
            }
            catch (Exception e)
            {
                throw new Exception("Exception");
            }

            return null;
        }
        public AllHddMetricsResponse GetHddMetrics(MetricsCreateRequest<HddMetricsController> request)
        {
            HttpClient httpClient = new HttpClient();
            var fromParameter = request.From.TotalSeconds;
            var toParameter = request.To.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{_client}/api/metrics/hdd/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllHddMetricsResponse>(responseStream).Result;
            }
            catch (Exception e)
            {
                throw new Exception("Exception");
            }

            return null;
        }
        public AllDotNetMetricsResponse GetDotNetMetrics(MetricsCreateRequest<DotNetMetricsController> request)
        {
            HttpClient httpClient = new HttpClient();
            var fromParameter = request.From.TotalSeconds;
            var toParameter = request.To.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{_client}/api/metrics/dotnet/errors-count/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllDotNetMetricsResponse>(responseStream).Result;
            }
            catch (Exception e)
            {
                throw new Exception("Exception");
            }

            return null;
        }
        public AllNetworkMetricsResponse GetNetworkMetrics(MetricsCreateRequest<NetworkMetricsController> request)
        {
            HttpClient httpClient = new HttpClient();
            var fromParameter = request.From.TotalSeconds;
            var toParameter = request.To.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{_client}/api/metrics/network/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllNetworkMetricsResponse>(responseStream).Result;
            }
            catch (Exception e)
            {
                throw new Exception("Exception");
            }

            return null;
        }
        public AllRamMetricsResponse GetRamMetrics(MetricsCreateRequest<RamMetricsController> request)
        {
            HttpClient httpClient = new HttpClient();
            var fromParameter = request.From.TotalSeconds;
            var toParameter = request.To.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{_client}/api/metrics/ram/available/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllRamMetricsResponse>(responseStream).Result;
            }
            catch (Exception e)
            {
                throw new Exception("Exception");
            }

            return null;
        }
    }
}
