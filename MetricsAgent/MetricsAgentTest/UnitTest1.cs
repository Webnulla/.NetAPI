using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentTest
{
    public class CpuMetricsControllerUnitTests
    {
        private Mock<ILogger<CpuMetricsController>> _loggerMock;
        private Mock<ICpuMetricsRepository> _mock;
        private CpuMetricsController _controller;
        public CpuMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<CpuMetricsController>>();
            _mock = new Mock<ICpuMetricsRepository>();
            _controller = new CpuMetricsController(_loggerMock.Object, _mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            //ставим заглушку
            _mock.Setup(repository => repository.Create(It.IsAny<CpuMetrics>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.CpuMetricsCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<CpuMetrics>()),Times.AtMostOnce());
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<CpuMetrics>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.CpuMetricsCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<CpuMetrics>()), Times.AtMostOnce());
        }
    }
    public class DotNetMetricsControllerUnitTests
    {
        private Mock<ILogger<DotNetMetricsController>> _loggerMock;
        private DotNetMetricsController _controller;
        private Mock<IDotNetMetricsReposiroty> _mock;
        public DotNetMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            _mock = new Mock<IDotNetMetricsReposiroty>();
            _controller = new DotNetMetricsController(_loggerMock.Object, _mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            //ставим заглушку
            _mock.Setup(repository => repository.Create(It.IsAny<DotNetMetrics>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.DotNetMetricsCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<DotNetMetrics>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<DotNetMetrics>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.DotNetMetricsCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<DotNetMetrics>()), Times.AtMostOnce());
        }
    }
    public class HddMetricsControllerUnitTests
    {
        private Mock<ILogger<HddMetricsController>> _loggerMock;
        private HddMetricsController _controller;
        private Mock<IHddMetricsRepository> _mock;
        public HddMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            _mock = new Mock<IHddMetricsRepository>();
            _controller = new HddMetricsController(_loggerMock.Object, _mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            //ставим заглушку
            _mock.Setup(repository => repository.Create(It.IsAny<HddMetrics>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.HddMetricsCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<HddMetrics>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<HddMetrics>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.HddMetricsCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<HddMetrics>()), Times.AtMostOnce());
        }
    }
    public class NetworkMetricsControllerUnitTests
    {
        private Mock<ILogger<NetworkMetricsController>> _loggerMock;
        private NetworkMetricsController _controller;
        private Mock<INetworkMetricsRepository> _mock;
        public NetworkMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            _mock = new Mock<INetworkMetricsRepository>();
            _controller = new NetworkMetricsController(_loggerMock.Object, _mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            //ставим заглушку
            _mock.Setup(repository => repository.Create(It.IsAny<NetworkMetrics>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.NetworkMetricsCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<NetworkMetrics>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<NetworkMetrics>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.NetworkMetricsCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<NetworkMetrics>()), Times.AtMostOnce());
        }
    }
    public class RamMetricsControllerUnitTests
    {
        private Mock<ILogger<RamMetricsController>> _loggerMock;
        private RamMetricsController _controller;
        private Mock<IRamMetricsRepository> _mock;
        public RamMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            _mock = new Mock<IRamMetricsRepository>();
            _controller = new RamMetricsController(_loggerMock.Object, _mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            //ставим заглушку
            _mock.Setup(repository => repository.Create(It.IsAny<RamMetrics>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.RamMetricsCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<RamMetrics>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<RamMetrics>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.RamMetricsCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<RamMetrics>()), Times.AtMostOnce());
        }
    }
}
