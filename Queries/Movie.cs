using System;
using System.Collections.Generic;
using System.Text;

namespace Queries
{
    public class Movie
    {
        int _year;
        public int Year
        {
            get
            {
                throw new Exception("Error!");
                Console.WriteLine($"Returning {_year} for {Title}");
                return _year;
            }
            set
            {
                _year = value;
            }
        }
        //Automatic get and set 
        public string Title { get; set; }
        public double Rating { get; set; }

        
    }
}
