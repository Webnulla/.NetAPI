using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WeatherHW.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public static List<WeatherForecast> weatherForecastList = new List<WeatherForecast>
        {

            new WeatherForecast
            {
                Id = 1,
                Date = DateTime.Today,
                TemperatureMin = 45 ,
                TemperatureMax = 56,
                Summary = WeatherEnum.Scorching
            },
            new WeatherForecast
            {
                Id = 2,
                Date = DateTime.Today,
                TemperatureMin = 0 ,
                TemperatureMax = 3,
                Summary = WeatherEnum.Cool
            }
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return weatherForecastList;
        }
        [HttpGet("{id}")]
        public WeatherForecast Get(int id) => weatherForecastList.FirstOrDefault(wi => wi.Id == id);

        [HttpPost]
        public ActionResult Post([FromBody] WeatherForecast weatherForecast)
        {
            if (weatherForecastList.Any(w => w.Id == weatherForecast.Id))
            {
                return this.StatusCode((int)HttpStatusCode.Conflict);
            }
            weatherForecastList.Add(weatherForecast);
            return this.Ok();
        }
        //для коректной работы требуется в Постмене указать номер id, например .../weatherforecast/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] WeatherForecast weatherForecast)
        {
            var index = weatherForecastList.FindIndex(w => w.Id == weatherForecast.Id);
            if (index < 0)
            {
                return this.StatusCode((int)HttpStatusCode.NotFound);
            }
            weatherForecastList.RemoveAt(index);
            weatherForecastList.Add(weatherForecast);
            return this.Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var index = weatherForecastList.FindIndex(w => w.Id == id);
            if (index < 0)
            {
                return this.StatusCode((int)HttpStatusCode.NotFound);
            }
            weatherForecastList.RemoveAt(index);
            
            return this.Ok();
        }
    }
}
