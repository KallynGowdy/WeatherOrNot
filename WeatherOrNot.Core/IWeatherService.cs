using System.Threading.Tasks;
using WeatherOrNot.Core.Models;

namespace WeatherOrNot.Core
{
    /// <summary>
    /// Defines an interface for objects that are able to retrieve a set of weather data.
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Gets the weather for the given latitude and longitude.
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        Task<IWeatherData> GetWeather(double lat, double lon);
    }
}