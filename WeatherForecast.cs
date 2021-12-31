using System;

namespace WeatherHW
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureMin { get; set; }

        public int TemperatureMax { get; set; }

        public WeatherEnum Summary  { get; set; }
    }
}
