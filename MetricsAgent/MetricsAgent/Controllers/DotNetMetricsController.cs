using MetricsAgent.DAL;
using MetricsAgent.Model;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet/errors-count")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        private IDotNetMetricsReposiroty _repository;

        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, IDotNetMetricsReposiroty repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogError(1, "Working....");
            return Ok();
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogError(1, "Working....");
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricsCreateRequest request)
        {
            _repository.Create(new DotNetMetrics
            {
                Time = request.Time,
                Value = request.Value,
            });
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _repository.GetAll();

            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricsDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new DotNetMetricsDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }
            return Ok(response);
        }
    }
}
