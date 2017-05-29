using System;
using System.Collections.Generic;
using System.Text;
using NodaTime;

namespace WeatherOrNot.Core.Models.DarkSky
{
    public class DarkSkyForecast : IForecast
    {
        public ForecastType Type { get; set; }
        public Instant Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public string Description { get; set; }
    }
}
