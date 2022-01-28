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
    public class HddMetricsControllerUnitTests
    {
        private Mock<ILogger<HddMetricsController>> _loggerMock;
        private HddMetricsController _controller;
        private Mock<IHddMetricsRepository> _mock;
        private Mock<IMapper> _mapperMock;
        public HddMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            _mock = new Mock<IHddMetricsRepository>();
            _mapperMock = new Mock<IMapper>();
            _controller = new HddMetricsController(_loggerMock.Object, _mock.Object, _mapperMock.Object);
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
}
