using System;
using WeatherServices;

namespace facade1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string zipCode = "83714";

            GeoLookupService geoLookupService = new GeoLookupService();
            
            var city = geoLookupService.GetCityForZipCode(zipCode);
            var state = geoLookupService.GetStateForZipCode(zipCode);
            var coords = geoLookupService.GetCoordinatesForZipCode(zipCode);

            WeatherService weatherService = new WeatherService();
            var farenheit = weatherService.GetTempFarenheit(coords.Latitude, coords.Longitude);

            EnglishMetricConverter englishMetricConverter = new EnglishMetricConverter();
            var celcius = englishMetricConverter.FarenheitToCelcious(farenheit);

            Console.WriteLine("The current temperature is {0}F/{1}C. in {2}, {3}", 
                                farenheit.ToString("F1"), 
                                celcius.ToString("F1"), 
                                city, 
                                state);
        }
    }
}
