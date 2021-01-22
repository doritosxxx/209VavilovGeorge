using System;

namespace task3
{
    class TemperatureConverterImp
    {
        public double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        public double CelsiusToFahrenheit(double celsius)
        {
            return 9 * celsius / 5 + 32;
        }
    }

    static class StaticTempConverts
    {
        public static double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }

        public static double CelsiusToRankin(double celsius)
        {
            return (celsius + 273.15) * 9 / 5;
        }

        public static double CelsiusToReaumur(double celsius)
        {
            return celsius * 4 / 5;
        }


        public static double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }

        public static double RankinToCelsius(double rankin)
        {
            return rankin * 5 / 9 - 273.15;
        }

        public static double ReaumurToCelsius(double reaumur)
        {
            return reaumur * 5 / 9 ;
        }

    }

    class Program
    {
        delegate double delegateConvertTemperature(double degrees);
        static void Main(string[] args)
        {
            // Main task.
            TemperatureConverterImp temperatureConverterImp = new TemperatureConverterImp();

            delegateConvertTemperature FahrenheitToCelsius = temperatureConverterImp.FahrenheitToCelsius;
            delegateConvertTemperature CelsiusToFahrenheit = temperatureConverterImp.CelsiusToFahrenheit;

            Console.WriteLine(FahrenheitToCelsius(1));
            Console.WriteLine(CelsiusToFahrenheit(1));

            // Subtasks.
            Console.WriteLine("\nSubtasks");

            delegateConvertTemperature[] converters = {
                temperatureConverterImp.FahrenheitToCelsius,
                temperatureConverterImp.CelsiusToFahrenheit
            };

            foreach (var function in converters)
                Console.WriteLine(function(1));

            delegateConvertTemperature[] convertersFromCelsius = {
                temperatureConverterImp.CelsiusToFahrenheit,
                StaticTempConverts.CelsiusToKelvin,
                StaticTempConverts.CelsiusToRankin,
                StaticTempConverts.CelsiusToReaumur
            };


            double celsius;

            Console.WriteLine("Enter temperature in celsius:");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out celsius))
                    break;
                Console.WriteLine("Provided input is not a double");
            }

            foreach(var converter in convertersFromCelsius)
                Console.WriteLine($"{converter.Method.Name}: {converter(celsius)}");
        }
    }
}
