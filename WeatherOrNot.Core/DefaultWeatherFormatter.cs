using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherOrNot.Core.Models;

namespace WeatherOrNot.Core
{
    public class DefaultWeatherFormatter : IWeatherFormatter
    {
        public string Format(IWeatherData data)
        {
            StringBuilder str = new StringBuilder();

            var current = data.Forecasts.First(f => f.Type == ForecastType.Current);

            str.AppendLine("Weather:");
            str.AppendLine();
            str.AppendFormat("Now: {0}", current.Description, current.High, current.Low);
            str.AppendLine();
            str.AppendFormat("Feels Like: {0} {1}", Math.Round(current.High), data.TemperatureUnit);

            return str.ToString();
        }
    }
}
