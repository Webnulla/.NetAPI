using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class CpuMetricsControllerUnitTests
    {
        private Mock<ILogger<CpuMetricsController>> _loggerMock;
        private CpuMetricsController _controller;
        public CpuMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<CpuMetricsController>>();
            _controller = new CpuMetricsController(_loggerMock.Object);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var _controller = new CpuMetricsController(_loggerMock.Object);
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            var _controller = new CpuMetricsController(_loggerMock.Object);
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
    public class DotNetMetricsControllerUnitTests
    {
        private Mock<ILogger<DotNetMetricsController>> _loggerMock;
        private DotNetMetricsController _controller;
        public DotNetMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            _controller = new DotNetMetricsController(_loggerMock.Object);            
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var _controller = new DotNetMetricsController(_loggerMock.Object);
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            var _controller = new DotNetMetricsController(_loggerMock.Object);
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
    public class HddMetricsControllerUnitTests
    {
        private Mock<ILogger<HddMetricsController>> _loggerMock;
        private HddMetricsController _controller;
        public HddMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            _controller = new HddMetricsController(_loggerMock.Object);            
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var _controller = new HddMetricsController(_loggerMock.Object);
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            var _controller = new HddMetricsController(_loggerMock.Object);
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
    public class NetworkMetricsControllerUnitTests
    {
        private Mock<ILogger<NetworkMetricsController>> _loggerMock;
        private NetworkMetricsController _controller;
        public NetworkMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            _controller = new NetworkMetricsController(_loggerMock.Object);           
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var _controller = new NetworkMetricsController(_loggerMock.Object);
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            var _controller = new NetworkMetricsController(_loggerMock.Object);
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
    public class RamMetricsControllerUnitTests
    {
        private Mock<ILogger<RamMetricsController>> _loggerMock;
        private RamMetricsController _controller;
        public RamMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            _controller = new RamMetricsController(_loggerMock.Object);           
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var _controller = new RamMetricsController(_loggerMock.Object);
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            var _controller = new RamMetricsController(_loggerMock.Object);
            var result = _controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
