using System;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using WeatherOrNot.Core;

namespace WeatherOrNot
{
    /// <summary>
    /// Defines a console application that 
    /// </summary>
    public class Program
    {
        private TextWriter output;
        private IWeatherService weatherService;
        private IWeatherFormatter formatter;

        public Program(TextWriter output, IWeatherService weatherService)
        {
            this.output = output ?? throw new ArgumentNullException(nameof(output));
            this.weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            this.formatter = new DefaultWeatherFormatter();
        }

        public void Run(string[] args)
        {
            var cla = new CommandLineApplication(false) { Out = output };
            cla.HelpOption("-h | --help");
            var lat = cla.Argument("latitude", "The latitude", multipleValues: false);
            var lon = cla.Argument("longitude", "The longitude", multipleValues: false);

            cla.OnExecute(async () =>
            {
                double latitude;
                double longitude;
                if (lat.Value != null && lon.Value != null)
                {
                    try
                    {
                        latitude = Convert.ToDouble(TrimArgumentValue(lat));
                        longitude = Convert.ToDouble(TrimArgumentValue(lon));
                    }
                    catch (FormatException)
                    {
                        output.WriteLine("Both the latitude and longitude must be convertible to decimal values.");
                        cla.ShowHelp();
                        return 1;
                    }
                }
                else
                {
                    output.WriteLine("You must specify a latitude and longitude");
                    cla.ShowHelp();
                    return 1;
                }

                var data = await weatherService.GetWeather(latitude, longitude);
                output.WriteLine(formatter.Format(data));

                return 0;
            });



            cla.Execute(args);
        }

        private static string TrimArgumentValue(CommandArgument lon)
        {
            return lon.Value.Trim('"', '\'');
        }

        static void Main(string[] args)
        {
            new Program(Console.Out, new DarkSkyWeatherService(DarkSkyWeatherService.ApiKey)).Run(new[]
            {
                "42.846988",
                "\"-85.650766\""
            });
            //new Program(Console.Out, new DarkSkyWeatherService(DarkSkyWeatherService.ApiKey)).Run(args);
        }
    }
}