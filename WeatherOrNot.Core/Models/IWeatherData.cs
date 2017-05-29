using System;
using System.Collections.Generic;
using System.Text;

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
        /// Gets the city that the data is for.
        /// </summary>
        string City { get; }

        /// <summary>
        /// Gets the country that the data is for.
        /// </summary>
        string Country { get; }

        /// <summary>
        /// Gets the region that the data is for.
        /// </summary>
        string Region { get; }

        /// <summary>
        /// Gets the current temperature.
        /// </summary>
        double CurrentTemp { get; }

        /// <summary>
        /// Gets the description for the current condition.
        /// </summary>
        string CurrentConditionDescription { get; }

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
