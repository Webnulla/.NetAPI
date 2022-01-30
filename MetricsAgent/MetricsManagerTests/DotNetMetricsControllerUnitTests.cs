using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using MetricsManager.Client;
using Xunit;

namespace MetricsManagerTests
{
    public class DotNetMetricsControllerUnitTests
    {
        private Mock<ILogger<DotNetMetricsController>> _loggerMock;
        private Mock<IMetricsAgentClient> _metricsAgentClientMock;
        private DotNetMetricsController _controller;
        public DotNetMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            _metricsAgentClientMock = new Mock<IMetricsAgentClient>();
            _controller = new DotNetMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var _controller = new DotNetMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
            var result = _controller.GetMetricsFromAgent(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            var _controller = new DotNetMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
            var result = _controller.GetMetricsFromAgent(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
