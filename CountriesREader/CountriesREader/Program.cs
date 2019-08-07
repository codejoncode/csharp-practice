using System;

namespace CountriesREader
{
    class Program
    {
        static void Main(string[] args)
        {
            //@ causes the string literal causes the escape sequence to be ignored
            string filePath = @"C:\users\Jonathan\csharp\csharp-practice\csharp-practice\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);

            foreach (Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }
    }
}
