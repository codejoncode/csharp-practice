using System;
using System.Collections.Generic;

namespace CountriesREader
{
    class Program
    {
        static void Main(string[] args)
        {
            //@ causes the string literal causes the escape sequence to be ignored
            string filePath = @"C:\users\Jonathan\csharp\csharp-practice\csharp-practice\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);
            List<Country> countries = reader.ReadFirstAllCountries();
            Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            countries.Insert(lilliputIndex, lilliput);

            foreach (Country country in countries)
            {
                //right justifies at 15 characters so they line up nicely  = PadLeft(15)
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"{countries.Count} countries");
        }
    }
}
