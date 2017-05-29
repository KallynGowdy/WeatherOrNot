using System;
using System.Collections.Generic;
using System.Text;
using NodaTime;

namespace WeatherOrNot.Core.Models
{
    /// <summary>
    /// Defines an interface that represents weather data.
    /// </summary>
    public interface IWeatherData
    {
        /// <summary>
        /// Gets the array of forecasts that this data uses.
        /// </summary>
        IForecast[] Forecasts { get; }

        /// <summary>
        /// Gets the timezone that all of the dates are in.
        /// </summary>
        DateTimeZone TimeZone { get; }

        /// <summary>
        /// Gets the unit that the temperatures are in.
        /// </summary>
        string TemperatureUnit { get; }

        /// <summary>
        /// Gets the unit that the distances are in.
        /// </summary>
        string DistanceUnit { get; }

        /// <summary>
        /// Gets the unit that the pressures are in.
        /// </summary>
        string PressureUnit { get; }

        /// <summary>
        /// Gets the unit that the speeds are in.
        /// </summary>
        string SpeedUnit { get; }
    }
}
