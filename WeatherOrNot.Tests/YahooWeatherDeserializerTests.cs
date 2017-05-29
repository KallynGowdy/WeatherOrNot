using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using NodaTime;
using WeatherOrNot.Core;
using WeatherOrNot.Core.Models.Yahoo;
using Xunit;

namespace WeatherOrNot.Tests
{
    public class YahooWeatherDeserializerTests
    {
        private YahooWeatherDeserializer Subject { get; set; }

        public YahooWeatherDeserializerTests()
        {
            Subject = new YahooWeatherDeserializer();
        }

        [Theory]
        [MemberData(nameof(LoadTestWeatherJson), "TestWeatherDeserializesJson_Case1.json")]
        public void Test_Deserializes_Json(string json)
        {
            var result = Subject.Deserialize(json);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<YahooWeatherData>();
        }

        [Theory]
        [MemberData(nameof(LoadTestWeatherJson), "TestWeatherDeserializesJson_Case1.json")]
        public void Test_Deserializes_Current_Temp(string json)
        {
            var result = Subject.Deserialize(json);

            result.CurrentTemp.Should().Be(72d);
        }

        [Theory]
        [MemberData(nameof(LoadTestWeatherJson), "TestWeatherDeserializesJson_Case1.json")]
        public void Test_Deserializes_Current_Condition_Description(string json)
        {
            var result = Subject.Deserialize(json);

            result.CurrentConditionDescription.Should().Be("Mostly Sunny");
        }

        [Theory]
        [MemberData(nameof(LoadTestWeatherJson), "TestWeatherDeserializesJson_Case1.json")]
        public void Test_Deserializes_Units(string json)
        {
            var result = Subject.Deserialize(json);

            result.TemperatureUnit.Should().Be("F");
            result.DistanceUnit.Should().Be("mi");
            result.PressureUnit.Should().Be("in");
            result.SpeedUnit.Should().Be("mph");
        }

        [Theory]
        [MemberData(nameof(LoadTestWeatherJson), "TestWeatherDeserializesJson_Case1.json")]
        public void Test_Deserializes_Location(string json)
        {
            var result = Subject.Deserialize(json);

            result.City.Should().Be("Grand Rapids");
            result.Country.Should().Be("United States");
            result.Region.Should().Be("MI");
        }

        [Theory]
        [MemberData(nameof(LoadTestWeatherJson), "TestWeatherDeserializesJson_Case1.json")]
        public void Test_Deserializes_Forecasts(string json)
        {
            var result = Subject.Deserialize(json);

            result.Forecasts.ShouldAllBeEquivalentTo(new YahooForecast[]
            {
               new YahooForecast()
               {
                   Date = new LocalDate(2017, 5, 29),
                   High = 74,
                   Low = 54,
                   Description = "Sunny"
               },
                new YahooForecast()
                {
                    Date = new LocalDate(2017, 5, 30),
                    High = 67,
                    Low = 53,
                    Description = "Partly Cloudy"
                },
                new YahooForecast()
                {
                    Date = new LocalDate(2017, 5, 31),
                    High = 65,
                    Low = 50,
                    Description = "Partly Cloudy"
                },
                new YahooForecast()
                {
                    Date = new LocalDate(2017, 6, 1),
                    High = 72,
                    Low = 52,
                    Description = "Scattered Thunderstorms"
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
