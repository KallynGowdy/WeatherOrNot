using System;
using NodaTime;

namespace WeatherOrNot.Core.Models
{
    /// <summary>
    /// Defines a forecast.
    /// </summary>
    public interface IForecast
    {
        LocalDate Date { get; }
        double High { get; }
        double Low { get; }
        string Description { get; }
    }
}