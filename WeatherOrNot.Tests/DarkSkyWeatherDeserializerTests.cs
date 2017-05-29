using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using NodaTime;
using WeatherOrNot.Core;
using WeatherOrNot.Core.Models;
using WeatherOrNot.Core.Models.DarkSky;
using Xunit;

namespace WeatherOrNot.Tests
{
    public class DarkSkyWeatherDeserializerTests
    {
        private DarkSkyWeatherDeserializer Subject { get; set; }

        public DarkSkyWeatherDeserializerTests()
        {
            Subject = new DarkSkyWeatherDeserializer();
        }

        [Theory]
        [MemberData(nameof(LoadTestWeatherJson), "TestWeatherDeserializesJson_Case1.json")]
        public void Test_Deserializes_Json(string json)
        {
            var result = Subject.Deserialize(json);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<DarkSkyWeatherData>();
        }

        [Theory]
        [MemberData(nameof(LoadTestWeatherJson), "TestWeatherDeserializesJson_Case1.json")]
        public void Test_Deserializes_Units(string json)
        {
            var result = Subject.Deserialize(json);

            result.TemperatureUnit.Should().Be("F");
            result.DistanceUnit.Should().Be("MI");
            result.PressureUnit.Should().Be("IN");
            result.SpeedUnit.Should().Be("MPH");
        }

        [Theory]
        [MemberData(nameof(LoadTestWeatherJson), "TestWeatherDeserializesJson_Case1.json")]
        public void Test_Deserializes_Forecasts(string json)
        {
            var result = Subject.Deserialize(json);

            result.Forecasts.ShouldAllBeEquivalentTo(new[]
            {
               new DarkSkyForecast()
               {
                   Type = ForecastType.Current,
                   Date = Instant.FromUnixTimeSeconds(1453402675),
                   High = 46.93,
                   Low = 46.93,
                   Description = "Rain"
               },
               new DarkSkyForecast()
               {
                   Type = ForecastType.Minutely,
                   Date = Instant.FromUnixTimeSeconds(1453402620),
                   High = double.NaN,
                   Low = double.NaN,
                   Description = "Rain for the hour."
               },
                new DarkSkyForecast()
                {
                    Type = ForecastType.Hourly,
                    Date = Instant.FromUnixTimeSeconds(1453399200),
                    High = 46.41,
                    Low = 46.41,
                    Description = "Rain throughout the day."
                },
                new DarkSkyForecast()
                {
                    Type = ForecastType.Daily,
                    Date = Instant.FromUnixTimeSeconds(1453363200),
                    High = 53.27,
                    Low = 36.68,
                    Description = "Light rain throughout the week, with temperatures bottoming out at 48°F on Sunday."
                }
            });
        }

        public static IEnumerable<object[]> LoadTestWeatherJson(string filename)
        {
            using (StreamReader fs = new StreamReader(File.OpenRead(Path.Combine("DataSets", filename))))
            {
                return new List<object[]>()
                {
                    new object[] { fs.ReadToEnd() }
                };
            }
        }
    }
}
