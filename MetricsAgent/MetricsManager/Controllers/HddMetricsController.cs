﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using MetricsAgent.Requests;
using MetricsManager.Client;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/hdd/left")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly ILogger<HddMetricsController> _logger;
        private IMetricsAgentClient _metricsAgentClient;
        public HddMetricsController(ILogger<HddMetricsController> logger, IMetricsAgentClient metricsAgentClient)
        {
            _logger = logger;
            _metricsAgentClient = metricsAgentClient;
        }
        
        /// <summary>
        /// Получает метрики CPU на заданном диапазоне времени
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET hddnetmetrics/from/1/to/9999999999
        ///
        /// </remarks>
        /// <param name="fromTime">начальная метрка времени в секундах с 01.01.1970</param>
        /// <param name="toTime">конечная метрка времени в секундах с 01.01.1970</param>
        /// <returns>Список метрик, которые были сохранены в заданном диапазоне времени</returns>
        /// <response code="201">Если все хорошо</response>
        /// <response code="400">Если передали не правильные параvетры</response>

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, 
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation(($"starting new request to metrics agent"));
            var metrics = _metricsAgentClient.GetAllHddMetrics(
                new MetricsCreateRequest<HddMetricsController>(fromTime, toTime));
            return Ok(metrics);
        }
        
        /// <summary>
        /// Получает метрики CPU на заданном диапазоне времени
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET hddnetmetrics/from/1/to/9999999999
        ///
        /// </remarks>
        /// <param name="fromTime">начальная метрка времени в секундах с 01.01.1970</param>
        /// <param name="toTime">конечная метрка времени в секундах с 01.01.1970</param>
        /// <returns>Список метрик, которые были сохранены в заданном диапазоне времени</returns>
        /// <response code="201">Если все хорошо</response>
        /// <response code="400">Если передали не правильные параvетры</response>

        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAgent([FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation(($"starting new request to metrics agent"));
            var metrics = _metricsAgentClient.GetAllHddMetrics(
                new MetricsCreateRequest<HddMetricsController>(fromTime, toTime));
            return Ok(metrics);
        }
    }
}
