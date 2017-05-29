using System;
using System.Collections.Generic;
using System.Text;
using WeatherOrNot.Core.Models;

namespace WeatherOrNot.Core
{
    /// <summary>
    /// Defines an interface for objects that can deserialize <see cref="IWeatherData"/> from a string.
    /// </summary>
    public interface IWeatherDeserializer
    {
        /// <summary>
        /// Deserializes the given serialized data into a <see cref="IWeatherData"/> object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        IWeatherData Deserialize(string data);
    }
}
