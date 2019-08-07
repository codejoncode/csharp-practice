using System.Collections.Generic;
using System.IO;

namespace CountriesREader
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public List<Country> ReadFirstAllCountries()
        {
            List<Country> countries = new List<Country>();
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
                    countries.Add(ReadCountryFromCsvLine(csvLine));
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

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }
    }
}