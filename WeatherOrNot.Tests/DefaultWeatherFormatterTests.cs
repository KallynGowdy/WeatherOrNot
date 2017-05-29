using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using WeatherOrNot.Core;
using WeatherOrNot.Core.Models;
using WeatherOrNot.Core.Models.DarkSky;
using Xunit;

namespace WeatherOrNot.Tests
{
    public class DefaultWeatherFormatterTests
    {
        private DefaultWeatherFormatter Subject { get; set; }

        public DefaultWeatherFormatterTests()
        {
            Subject = new DefaultWeatherFormatter();
        }

        [Theory]
        [InlineData(10, "10")]
        [InlineData(15.5, "16")]
        [InlineData(15.4, "15")]
        [InlineData(15.6, "16")]
        public void Test_Rounds_The_Current_Temperature(double temp, string expected)
        {
            var data = new DarkSkyWeatherData()
            {
                Forecasts = new IForecast[] {
                    new DarkSkyForecast()
                    {
                        Type = ForecastType.Current,
                        Low = temp,
                        High = temp,
                        Description = ""
                    }
                }
            };

            var result = Subject.Format(data);

            result.Should().Contain(expected);
        }

        [Fact]
        public void Test_Displays_The_Current_Description()
        {
            var data = new DarkSkyWeatherData()
            {
                Forecasts = new IForecast[] {
                    new DarkSkyForecast()
                    {
                        Type = ForecastType.Current,
                        Low = 0,
                        High = 0,
                        Description = "Rain"
                    }
                }
            };

            var result = Subject.Format(data);

            result.Should().Contain("Rain");
        }

    }
}
