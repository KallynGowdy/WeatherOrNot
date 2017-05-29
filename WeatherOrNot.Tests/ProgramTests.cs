using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using NSubstitute;
using WeatherOrNot.Core;
using Xunit;

namespace WeatherOrNot.Tests
{
    public class ProgramTests
    {
        public Program Subject { get; set; }
        public StringWriter Out { get; set; }
        public string Output => Out.ToString();
        public IWeatherService WeatherService { get; set; }

        public ProgramTests()
        {
            Out = new StringWriter();
            WeatherService = Substitute.For<IWeatherService>();
            Subject = new Program(Out, WeatherService);
        }

        [Fact]
        public void Test_Outputs_Friendly_Message_When_Given_Invalid_Numbers()
        {
            Subject.Run(new[]
            {
                "abc",
                "def"
            });

            Output.Should().Contain("Both the latitude and longitude must be convertible to decimal values.");
        }

        [Theory]
        [InlineData("-h")]
        [InlineData("--help")]
        public void Test_Outputs_Help_Text_When_Given_Help_Argument(string help)
        {
            Subject.Run(new[] { help });

            Output.Should().NotBeNullOrWhiteSpace().And.Contain("Usage");
        }
    }
}
