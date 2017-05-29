using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherOrNot.Core.Models;

namespace WeatherOrNot.Core
{
    public class DarkSkyWeatherService : IWeatherService
    {
        public const string ApiKey = "089c6f4e99628a20fd3c3f8ccd65c8a9";
        private static readonly DarkSkyWeatherDeserializer Deserializer = new DarkSkyWeatherDeserializer();

        private readonly string forecastUrl;
        private readonly HttpClient client;
        private readonly string apiKey;

        public DarkSkyWeatherService(string apiKey)
        {
            this.apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            forecastUrl = $"https://api.darksky.net/forecast/{apiKey}";
            this.client = new HttpClient();
        }

        public async Task<IWeatherData> GetWeather(double lat, double lon)
        {
            var url = $"{forecastUrl}/{lat},{lon}";
            var json = await client.GetStringAsync(url);
            return Deserializer.Deserialize(json);
        }
    }
}

