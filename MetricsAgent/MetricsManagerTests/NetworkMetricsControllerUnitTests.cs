using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using MetricsManager.Client;
using Xunit;

namespace MetricsManagerTests
{
    public class NetworkMetricsControllerUnitTests
    {
        private Mock<ILogger<NetworkMetricsController>> _loggerMock;
        private Mock<IMetricsAgentClient> _metricsAgentClientMock;
        private NetworkMetricsController _controller;
        public NetworkMetricsControllerUnitTests()
        {
            _metricsAgentClientMock = new Mock<IMetricsAgentClient>();
            _loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            _controller = new NetworkMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var _controller = new NetworkMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
            var result = _controller.GetMetricsFromAgent(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            var _controller = new NetworkMetricsController(_loggerMock.Object, _metricsAgentClientMock.Object);
            var result = _controller.GetMetricsFromAgent(TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
