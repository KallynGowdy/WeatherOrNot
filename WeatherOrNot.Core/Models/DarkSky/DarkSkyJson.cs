using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherOrNot.Core.Models.DarkSky
{
    public class Currently
    {
        public int Time { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public int NearestStormDistance { get; set; }
        public double PrecipIntensity { get; set; }
        public double PrecipIntensityError { get; set; }
        public int PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public double Temperature { get; set; }
        public double ApparentTemperature { get; set; }
        public double DewPoint { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int WindBearing { get; set; }
        public double Visibility { get; set; }
        public double CloudCover { get; set; }
        public double Pressure { get; set; }
        public double Ozone { get; set; }
    }

    public class Datum
    {
        public int Time { get; set; }
        public double PrecipIntensity { get; set; }
        public double PrecipIntensityError { get; set; }
        public int PrecipProbability { get; set; }
        public string PrecipType { get; set; }
    }

    public class Minutely
    {
        public string Summary { get; set; }
        public string Icon { get; set; }
        public List<Datum> Data { get; set; }
    }

    public class Datum2
    {
        public int Time { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public double PrecipIntensity { get; set; }
        public double PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public double Temperature { get; set; }
        public double ApparentTemperature { get; set; }
        public double DewPoint { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int WindBearing { get; set; }
        public double Visibility { get; set; }
        public double CloudCover { get; set; }
        public double Pressure { get; set; }
        public double Ozone { get; set; }
    }

    public class Hourly
    {
        public string Summary { get; set; }
        public string Icon { get; set; }
        public List<Datum2> Data { get; set; }
    }

    public class Datum3
    {
        public int Time { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public int SunriseTime { get; set; }
        public int SunsetTime { get; set; }
        public double MoonPhase { get; set; }
        public double PrecipIntensity { get; set; }
        public double PrecipIntensityMax { get; set; }
        public int PrecipIntensityMaxTime { get; set; }
        public double PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public double TemperatureMin { get; set; }
        public int TemperatureMinTime { get; set; }
        public double TemperatureMax { get; set; }
        public int TemperatureMaxTime { get; set; }
        public double ApparentTemperatureMin { get; set; }
        public int ApparentTemperatureMinTime { get; set; }
        public double ApparentTemperatureMax { get; set; }
        public int ApparentTemperatureMaxTime { get; set; }
        public double DewPoint { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int WindBearing { get; set; }
        public double Visibility { get; set; }
        public double CloudCover { get; set; }
        public double Pressure { get; set; }
        public double Ozone { get; set; }
    }

    public class Daily
    {
        public string Summary { get; set; }
        public string Icon { get; set; }
        public List<Datum3> Data { get; set; }
    }

    public class Alert
    {
        public string Title { get; set; }
        public int Time { get; set; }
        public int Expires { get; set; }
        public string Description { get; set; }
        public string Uri { get; set; }
    }

    public class Flags
    {
        public string Units { get; set; }
    }

    public class DarkSkyReport
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }
        public Currently Currently { get; set; }
        public Minutely Minutely { get; set; }
        public Hourly Hourly { get; set; }
        public Daily Daily { get; set; }
        public List<Alert> Alerts { get; set; }
        public Flags Flags { get; set; }
    }
}
