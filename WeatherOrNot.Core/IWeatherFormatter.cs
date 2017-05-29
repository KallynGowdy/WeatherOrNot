using System;
using System.Collections.Generic;
using System.Text;
using WeatherOrNot.Core.Models;

namespace WeatherOrNot.Core
{
    /// <summary>
    /// Defines an interface for an object that can format <see cref="IWeatherData"/>.
    /// </summary>
    public interface IWeatherFormatter
    {
        /// <summary>
        /// Formats the given data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string Format(IWeatherData data);
    }
}
