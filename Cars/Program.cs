using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            var query = cars.OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name); // secondary sort if there is a tie

            query =
                from car in cars
                orderby car.Combined descending, car.Name ascending
                select car; 
            //don't need ascending as it is the default but showing off the keyword. 

            foreach ( var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            /*Method syntax*/
            //return
            //File.ReadAllLines(path)
            //    .Skip(1)//skip the header
            //    .Where(line => line.Length > 1)
            //    .Select(Car.ParseFromCsv)
            //    .ToList();
            /*The same as the above below query syntax */
            var query =
            from line in File.ReadAllLines(path).Skip(1)
            where line.Length > 1
            select Car.ParseFromCsv(line);
            return query.ToList();

        }

        
    }
}
