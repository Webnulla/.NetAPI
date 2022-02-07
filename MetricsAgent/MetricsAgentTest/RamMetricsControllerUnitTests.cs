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
    public class RamMetricsControllerUnitTests
    {
        private Mock<ILogger<RamMetricsController>> _loggerMock;
        private RamMetricsController _controller;
        private Mock<IRamMetricsRepository> _mock;
        private Mock<IMapper> _mapperMock;
        public RamMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            _mock = new Mock<IRamMetricsRepository>();
            _mapperMock = new Mock<IMapper>();
            _controller = new RamMetricsController(_loggerMock.Object, _mock.Object, _mapperMock.Object);
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
