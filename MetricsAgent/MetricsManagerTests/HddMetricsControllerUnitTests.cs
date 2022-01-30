using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using MetricsManager.Client;
using Xunit;

namespace MetricsManagerTests
{
    public class HddMetricsControllerUnitTests
    {
        private Mock<ILogger<HddMetricsController>> _loggerMock;
        private HddMetricsController _controller;
        private Mock<IMetricsAgentClient> _metricsAgentClientMock;
        public HddMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            _metricsAgentClientMock = new Mock<IMetricsAgentClient>();
            _controller = new HddMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var _controller = new HddMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
            var result = _controller.GetMetricsFromAgent(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            var _controller = new HddMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
            var result = _controller.GetMetricsFromAgent(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
