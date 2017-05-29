using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NodaTime.Text;
using WeatherOrNot.Core.Models;
using WeatherOrNot.Core.Models.Yahoo;

namespace WeatherOrNot.Core
{
    public class YahooWeatherDeserializer : IWeatherDeserializer
    {
        private static readonly LocalDatePattern DatePattern =
            NodaTime.Text.LocalDatePattern.Create("dd MMM yyyy", CultureInfo.CurrentCulture);

        public IWeatherData Deserialize(string data)
        {
            var deserialized = JsonConvert.DeserializeObject<dynamic>(data);
            var query = deserialized.query;
            var results = query.results;
            var channel = results.channel;
            var location = channel.location;
            var units = channel.units;
            var item = channel.item;
            var condition = item.condition;
            var forecast = (IEnumerable<dynamic>)item.forecast;
            return new YahooWeatherData()
            {
                City = location.city,
                Country = location.country,
                Region = location.region,
                TemperatureUnit = units.temperature,
                DistanceUnit = units.distance,
                SpeedUnit = units.speed,
                PressureUnit = units.pressure,
                CurrentConditionDescription = condition.text,
                CurrentTemp = condition.temp,
                Forecasts = forecast.Select(f =>
                {
                    string date = f.date;
                    return new YahooForecast()
                    {
                        Date = DatePattern.Parse(date).Value,
                        Low = f.low,
                        High = f.high,
                        Description = f.text
                    };
                }).Cast<IForecast>().ToArray()
            };
        }
    }
}