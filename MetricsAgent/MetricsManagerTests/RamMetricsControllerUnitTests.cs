using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using MetricsManager.Client;
using Xunit;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTests
    {
        private Mock<ILogger<RamMetricsController>> _loggerMock;
        private Mock<IMetricsAgentClient> _metricsAgentClientMock;
        private RamMetricsController _controller;
        public RamMetricsControllerUnitTests()
        {
            _metricsAgentClientMock = new Mock<IMetricsAgentClient>();
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            _controller = new RamMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var _controller = new RamMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
            var result = _controller.GetMetricsFromAgent(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            var _controller = new RamMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
            var result = _controller.GetMetricsFromAgent(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
