using System;
using System.Collections.Generic;
using System.Linq;

namespace CountriesREader
{
    class Program
    {
        static void Main(string[] args)
        {
            //@ causes the string literal causes the escape sequence to be ignored
            string filePath = @"C:\users\Jonathan\csharp\csharp-practice\csharp-practice\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);
            Dictionary<string, Country> countries = reader.ReadFirstAllCountries();
            //Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            //int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            //countries.Insert(lilliputIndex, lilliput);
            //countries.RemoveAt(lilliputIndex);
            Console.WriteLine("Which country code do you want to look up? ");
            string userInput = Console.ReadLine();

            bool gotCountry = countries.TryGetValue(userInput, out Country country);
            if (!gotCountry)
                Console.WriteLine($"Sorry, there is no country with code, {userInput}");
            else
                Console.WriteLine($"{country.Name} has population { PopulationFormatter.FormatPopulation(country.Population)}");

            //foreach (Country country in countries)
            //{
            //    //right justifies at 15 characters so they line up nicely  = PadLeft(15)
            //    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            //}

            //Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            //Country finland = new Country("Finland", "FIN", "Europe", 5_511_303);
            //Console.WriteLine($"{countries.Count} countries");
            //Dictionary<string, Country> countries2 = new Dictionary<string, Country>();
            //// initializer
            //var countries3 = new Dictionary<string, Country>
            //{
            //    { "NOR", norway },
            //    { "FIN", finland }
            //};
            //// Add throws an exception when you add the same key more than once
            //countries2.Add(norway.Code, norway);
            //countries2.Add(finland.Code, finland);

            //Country selectedCountry = countries3["NOR"];
            ////var is KeyValuePair<string, Country>
            //foreach(var country in countries3)
            //{
            //    Console.WriteLine(country.Value.Name);
            //}

            //foreach (var country in countries3.Values)
            //{
            //    Console.WriteLine(country.Name);
            //}

            //// allow for the possibilty of the item not being there 
            //bool exists = countries3.TryGetValue("MUS", out Country ctry);
            ////the above code also creaes a variable called ctry 
            //if (exists)
            //    Console.WriteLine(ctry.Name);
            //else
            //    Console.WriteLine("There is no country with the code MUS");
            //Console.WriteLine("Provide the max input to display");
            //userInput = Console.ReadLine();
            //bool exists = Int32.TryParse(userInput, out int maxToDisplay);
            //if (exists)
            //{
            //    for (int i = 0; i < countries.Count; i++)
            //    {
            //        if ( i > 0 && (i % maxToDisplay == 0))
            //        {
            //            Console.WriteLine("Hit return to continue, anything else to quit>");
            //            if (Console.ReadLine() != "")
            //            {
            //                break;
            //            }
            //        }
            //        Country item = countries[i];
            //        Console.WriteLine($"{PopulationFormatter.FormatPopulation(item.Population).PadLeft(15)}: {item.Name}");
            //    }
            //}

            // foreach is read only  only for reading a collection. can't modify in C# 
            foreach (var item in countries.Values)
            {
                //right justifies at 15 characters so they line up nicely  = PadLeft(15)
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(item.Population).PadLeft(15)}: {item.Name}");
            }
            Console.WriteLine($"{countries.Count} countries");

            // LINQ is read-only 
            // LINQ query syntax 

            //List  
            //foreach(Country country in countries.Take(10))
            //{

            //} 
            //foreach(var country in countries.OrderBy(x => x.Name).Take(10))
            //foreach(var country in countries.Take(10).OrderBy(x => x.Name)) will take 10 then order by alphabetical order. 
            //The chain queries the data in the collection 
            // Extension methods from System.Linq.Enumerable 
            /**
             * for loop Arrays and lists only   because requires an index 
             * Linq all collections including dictionaries 
             
             */
            foreach (var item in countries.Values.OrderBy(x => x.Name).Take(10))
            {
                //right justifies at 15 characters so they line up nicely  = PadLeft(15)
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(item.Population).PadLeft(15)}: {item.Name}");
            }
            // LINQ IS READ ONLY can filter items but not actually remove them
            foreach (var item in countries.Values.Where(x=> !x.Name.Contains(',')).Take(10))
            {
                //right justifies at 15 characters so they line up nicely  = PadLeft(15)
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(item.Population).PadLeft(15)}: {item.Name}");
            }

            var filteredCountries = countries.Values.Where(x => !x.Name.Contains(','));//now can  for each through.
            // query syntax
            var filteredCountries2 = from item in countries.Values
                                     where !item.Name.Contains(',')
                                     select item;

            /**
             * Complex queries can be more readable 
             * new syntax to learn 
             * doesn't support all LINQ features 
             * LINQ   Language Integrated Query
             * very simple code 
             * only for querying not modifying 
             * Good for productivity
             * 
             * for loop 
             * very flexible
             * Only for ordered collections  (no dictionaries) 
             * Most complex to code 
             * **/

            Dictionary<string, List<Country>> newCountries = reader.ReadAllCountries();
            foreach (string region in countries.Keys)
            {
                Console.Write($"{region} ");
            }

            Console.WriteLine("Which of the above regions do you want?");
            string chosenRegion = Console.ReadLine();

            if (countries.ContainsKey(chosenRegion))
            {
                foreach(Country country1 in countries[chosenRegion].Take(10))
                {
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
                }
            }
            else
            {
                Console.WriteLine("That is not a valid region");
            }

            //Jagged Array == Array of arrays. 
        }
    }
}
