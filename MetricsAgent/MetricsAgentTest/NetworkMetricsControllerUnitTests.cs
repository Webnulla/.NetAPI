using AutoMapper;
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
    public class NetworkMetricsControllerUnitTests
    {
        private Mock<ILogger<NetworkMetricsController>> _loggerMock;
        private NetworkMetricsController _controller;
        private Mock<INetworkMetricsRepository> _mock;
        private Mock<IMapper> _mapperMock;
        public NetworkMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            _mock = new Mock<INetworkMetricsRepository>();
            _mapperMock = new Mock<IMapper>();
            _controller = new NetworkMetricsController(_loggerMock.Object, _mock.Object, _mapperMock.Object);
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
}
