using System;
using System.Collections.Generic;
using System.Text;
using NodaTime;

namespace WeatherOrNot.Core.Models.DarkSky
{
    public class DarkSkyWeatherData : IWeatherData
    {
        public IForecast[] Forecasts { get; set; }
        public DateTimeZone TimeZone { get; set; }
        public string TemperatureUnit { get; set; }
        public string DistanceUnit { get; set; }
        public string PressureUnit { get; set; }
        public string SpeedUnit { get; set; }
    }
}
