using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using facade2.TemperatureFacade;

namespace facade2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string zipCode = "83714";

            var temperatureFacade = new TemperatureLookupFacade();
            LocalTemperature localTemp = temperatureFacade.GetTemperature(zipCode);

            Console.WriteLine("The current temperature is {0}F/{1}C. in {2}, {3}",
                                localTemp.Farenheit.ToString("F1"), 
                                localTemp.Celcius.ToString("F1"), 
                                localTemp.City, 
                                localTemp.State);
        }
    }
}
