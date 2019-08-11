using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountriesREader
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public Dictionary<string, Country> ReadFirstAllCountries()
        {
            var countries = new Dictionary<string, Country>();
            // can read text files 
            using (StreamReader sr = new StreamReader(_csvFilePath))// makes sure StreamReader is disposed of when we are done. 
            {
                //read header line 
                sr.ReadLine();
                string csvLine;
                //read the next line;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    // Parse the line to turn it into a Country instance
                    Country country = ReadCountryFromCsvLine(csvLine);
                    countries.Add(country.Code, country);
                }
            }

            return countries;
        }

        public Dictionary<string, List<Country>> ReadAllCountries ()
        {
            var countries = new Dictionary<string, List<Country>>();
            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //read header line 
                sr.ReadLine();
                string csvLine;
                //read the next line;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    // Parse the line to turn it into a Country instance
                    Country country = ReadCountryFromCsvLine(csvLine);
                    if (countries.ContainsKey(country.Region))
                    {
                        countries[country.Region].Add(country);
                    }
                    else
                    {
                        List<Country> countriesInRegion = new List<Country>() { country };
                        countries.Add(country.Region, countriesInRegion);
                    }
                }
            }

            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            //public String[] Split(params char[] separator);   params takes parmater and then it will build the arrray for you you
            //so params char[]  takes in arguments and then makes an array. 
            //allows us not to have to do this new char[] {','} as an argument. 
            string name;
            string code;
            string region;
            string popText;

            if(parts.Length == 5)
            {
                name = parts[0] + ", " + parts[1];

                name.Replace("\"", null).Trim();
                code = parts[2];
                region = parts[3];
                popText = parts[4];
            }
            else if (parts.Length == 4)
            {
                name = parts[0];
                code = parts[1];
                region = parts[2];
                popText = parts[3];
            }
            else
            {
                throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }

            //TryParse leaves population= 0 if can't parse 
            int.TryParse(popText, out int population);
            return new Country(name, code, region, population);
        }
        public void RemoveCommaCountries(List<Country> countries)
        {
            //iterate backwards when editing the list or array you are iterating over 
            /* going forward would skip items as you move to the next item  also want to work backwards when you want to insert or remove*/
            for (int i = countries.Count-1; i >= 0; i--)
            {
                if (countries[i].Name.Contains(','))
                    countries.RemoveAt(i);
            }

            //does the same thing as above
            countries.RemoveAll(x => x.Name.Contains(','));// LINQ can't do this  no designed to modify LINQ is read-only 

            //LINQ can filter the items. 



        }
    }
}