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
    public class DotNetMetricsControllerUnitTests
    {
        private Mock<ILogger<DotNetMetricsController>> _loggerMock;
        private DotNetMetricsController _controller;
        private Mock<IDotNetMetricsReposiroty> _mock;
        private Mock<IMapper> _mapperMock;
        public DotNetMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            _mock = new Mock<IDotNetMetricsReposiroty>();
            _mapperMock = new Mock<IMapper>();
            _controller = new DotNetMetricsController(_loggerMock.Object, _mock.Object, _mapperMock.Object);
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
}
