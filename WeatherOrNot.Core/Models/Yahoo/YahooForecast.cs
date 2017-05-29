using System;
using NodaTime;

namespace WeatherOrNot.Core.Models.Yahoo
{
    /// <summary>
    /// Defines a forecast that represents data from yahoo weather.
    /// </summary>
    public class YahooForecast : IForecast
    {
        public LocalDate Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public string Description { get; set; }
    }
}
