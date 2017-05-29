using System;
using System.IO;
using System.Linq;
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
            // Setup the command line arguments so we get nice help text
            var cla = new CommandLineApplication(false)
            {
                Out = output,
                FullName = "Weather Or Not?",
                Description = "A command line application that checks the weather"
            };
            cla.HelpOption("-h | --help");
            var lat = cla.Argument("latitude", "The latitude", multipleValues: false);
            var lon = cla.Argument("longitude", "The longitude", multipleValues: false);

            cla.OnExecute(async () =>
            {
                string latVal = lat.Value ?? cla.RemainingArguments.First();
                string lonVal = lon.Value ?? cla.RemainingArguments.Last();
                double latitude;
                double longitude;

                // Check for valid arguments
                if (latVal != null && lonVal != null)
                {
                    try
                    {
                        latitude = Convert.ToDouble(TrimArgumentValue(latVal));
                        longitude = Convert.ToDouble(TrimArgumentValue(lonVal));
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
                    output.WriteLine("You must specify a latitude and longitude. You can go to https://maps.google.com for reference.");
                    cla.ShowHelp();
                    return 1;
                }

                var data = await weatherService.GetWeather(latitude, longitude);
                output.WriteLine(formatter.Format(data));
                output.WriteLine();
                output.WriteLine("Powered by Dark Sky");

                return 0;
            });

            cla.Execute(args);
        }

        private static string TrimArgumentValue(string val)
        {
            return val.Trim('"', '\'');
        }

        static void Main(string[] args)
        {
            new Program(Console.Out, new DarkSkyWeatherService(DarkSkyWeatherService.ApiKey)).Run(args);
        }
    }
}