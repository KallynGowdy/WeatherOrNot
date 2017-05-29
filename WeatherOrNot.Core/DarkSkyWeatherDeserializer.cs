using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NodaTime;
using WeatherOrNot.Core.Models;
using WeatherOrNot.Core.Models.DarkSky;

namespace WeatherOrNot.Core
{
    public class DarkSkyWeatherDeserializer : IWeatherDeserializer
    {
        public IWeatherData Deserialize(string data)
        {
            var deserialized = JsonConvert.DeserializeObject<DarkSkyReport>(data, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var flags = deserialized.Flags;
            var units = flags.Units;
            var isUs = units == "us";
            var current = deserialized.Currently;
            var minute = deserialized.Minutely;
            var hour = deserialized.Hourly;
            var day = deserialized.Daily;
            return new DarkSkyWeatherData()
            {
                TemperatureUnit = isUs ? "F" : "C",
                DistanceUnit = isUs ? "MI" : "KM",
                PressureUnit = isUs ? "IN" : "CM",
                SpeedUnit = isUs ? "MPH" : "KPH",
                Forecasts = new IForecast[]
                {
                    new DarkSkyForecast()
                    {
                        Type = ForecastType.Current,
                        Date = Instant.FromUnixTimeSeconds(current.Time),
                        High = current.ApparentTemperature,
                        Low = current.ApparentTemperature,
                        Description = current.Summary
                    },
                    new DarkSkyForecast()
                    {
                        Type = ForecastType.Minutely,
                        Date = Instant.FromUnixTimeSeconds(minute.Data.First().Time),
                        High = double.NaN,
                        Low = double.NaN,
                        Description = minute.Summary
                    },
                    new DarkSkyForecast()
                    {
                        Type = ForecastType.Hourly,
                        Date = Instant.FromUnixTimeSeconds(hour.Data.First().Time),
                        High = hour.Data.Max(d => d.ApparentTemperature),
                        Low = hour.Data.Min(d => d.ApparentTemperature),
                        Description = hour.Summary
                    },
                    new DarkSkyForecast()
                    {
                        Type = ForecastType.Daily,
                        Date = Instant.FromUnixTimeSeconds(day.Data.First().Time),
                        High = day.Data.Max(d => d.ApparentTemperatureMax),
                        Low = day.Data.Min(d => d.ApparentTemperatureMin),
                        Description = day.Summary
                    }
                }
            };
        }
    }
}
