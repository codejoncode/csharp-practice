using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie {Title = "The Dark Knight", Rating = 8.9f, Year = 2008 },
                new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980 }
            };
            //query syntax  
            var query = from movie in movies
                        where movie.Year > 2000
                        select movie;
            
            //method syntax
            //where method  it takes a Func<Movie, bool>   bool is the return  and it takes a Movie
            var query2 = movies.Where(x => x.Year > 2000);

            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }

            foreach (var movie in query2)
            {
                Console.WriteLine(movie.Title);
            }


        }
    }
}
