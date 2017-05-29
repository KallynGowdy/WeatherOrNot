using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherOrNot.Core.Models.Yahoo
{
    public class YahooWeatherData : IWeatherData
    {
        private string region;
        private string country;
        private string city;
        public IForecast[] Forecasts { get; set; }

        public string City
        {
            get => city;
            set => city = value?.Trim();
        }

        public string Country
        {
            get => country;
            set => country = value?.Trim();
        }

        public string Region
        {
            get => region;
            set => region = value?.Trim();
        }

        public double CurrentTemp { get; set; }
        public string CurrentConditionDescription { get; set; }
        public string TemperatureUnit { get; set; }
        public string DistanceUnit { get; set; }
        public string PressureUnit { get; set; }
        public string SpeedUnit { get; set; }
    }
}
