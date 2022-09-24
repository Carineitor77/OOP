using System.Collections.Generic;
using System;

namespace OOP.Models.Lab1.Task3
{
    public class TemperatureRange
    {
        public TemperatureRange(List<double> range)
        {
            Fahrenheit = range;
            Celsius = GetCelsiusRange(range);
        }

        public List<double>? Fahrenheit { get; set; }
        public List<double>? Celsius { get; set; }

        private static List<double> GetCelsiusRange(List<double> range)
        {
            List<double> result = new List<double>();

            for (double i = range[0]; i <= range[^1]; i++)
            {
                result.Add(Math.Round((i - 32) / 1.8, 2));
            }

            return result;
        }
    }
}
