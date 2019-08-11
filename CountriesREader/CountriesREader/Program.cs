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
            countries.RemoveAt(lilliputIndex);

            foreach (Country country in countries)
            {
                //right justifies at 15 characters so they line up nicely  = PadLeft(15)
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }

            Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            Country finland = new Country("Finland", "FIN", "Europe", 5_511_303);
            Console.WriteLine($"{countries.Count} countries");
            Dictionary<string, Country> countries2 = new Dictionary<string, Country>();
            // initializer
            var countries3 = new Dictionary<string, Country>
            {
                { "NOR", norway },
                { "FIN", finland }
            };
            countries2.Add(norway.Code, norway);
            countries2.Add(finland.Code, finland);

            Country selectedCountry = countries3["NOR"];
            //var is KeyValuePair<string, Country>
            foreach(var country in countries3)
            {
                Console.WriteLine(country.Value.Name);
            }

            foreach (var country in countries3.Values)
            {
                Console.WriteLine(country.Name);
            }
        }
    }
}
