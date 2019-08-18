using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            var query =
                from car in cars
                    //this is like a inner join in SQL
                join manufacturer in manufacturers
                    on car.Manufacturer equals manufacturer.Name
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined
                };
            //method syntax
            var query2 =
                //smaller sequence should come first
                cars.Join(manufacturers,
                          c => c.Manufacturer,
                          m => m.Name, (c, m) => new
                          {
                              m.Headquarters,
                              c.Name,
                              c.Combined
                          })
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name);

            var query3 =
                //smaller sequence should come first
                cars.Join(manufacturers,
                          c => c.Manufacturer,
                          m => m.Name, (c, m) => new
                          {
                              Car = c, 
                              Manufacturer = m
                          })
                    .OrderByDescending(c => c.Car.Combined)
                    .ThenBy(c => c.Car.Name)
                    .Select(c => new
                    {
                        c.Manufacturer.Headquarters,
                        c.Car.Name,
                        c.Car.Combined
                    });
            //The above is doing the same thing only it provides a different type of object with 3 properties 
            /**
             *Headquarters, Name, Combined
             * The first part creates properties Car and Manufactuer and assigns the entire object as the properties value.
             * Then the second one takes only the desired data selects and returns it. 
             * 
             */


            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name} {car.Combined}");
            }
            Console.WriteLine("\n\n");

            foreach (var car in query2.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name} {car.Combined}");
            }

            Console.WriteLine("\n\n");

            foreach (var car in query2.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name} {car.Combined}");
            }
        }

        private static List<Manfacturer> ProcessManufacturers(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Where(l => l.Length > 1)
                    .Select(l =>
                    {
                        var columns = l.Split(',');
                        return new Manfacturer
                        {
                            Name = columns[0],
                            Headquarters = columns[1],
                            Year = int.Parse(columns[2])
                        };
                    });
            return query.ToList();
        }

        private static List<Car> ProcessCars(string path)
        {
            /*Method syntax*/
            //return
            //File.ReadAllLines(path)
            //    .Skip(1)//skip the header
            //    .Where(line => line.Length > 1)
            //    .Select(Car.ParseFromCsv)
            //    .ToList();
            /*The same as the above below query syntax */
            //var query =
            //from line in File.ReadAllLines(path).Skip(1)
            //where line.Length > 1
            //select Car.ParseFromCsv(line);

            // primary projection operator is select. 
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();

            return query.ToList();

        }


    }
    /// <summary>
    /// Custom linq method static class and static method 
    /// </summary>
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {

                var columns = line.Split(',');

                if (!(Int32.TryParse(columns[0], out int year)))
                {
                    throw new ArgumentException($"{columns[0]} cannot be converted to int");
                }
                if (!(Double.TryParse(columns[3], out double displacement)))
                {
                    throw new ArgumentException($"{columns[3]} cannot be converted to double");
                }

                if (!(Int32.TryParse(columns[4], out int cylinder)))
                {
                    throw new ArgumentException($"{columns[4]} cannot be converted to int");
                }

                if (!(Int32.TryParse(columns[5], out int city)))
                {
                    throw new ArgumentException($"{columns[5]} cannot be converted to int");
                }

                if (!(Int32.TryParse(columns[6], out int highway)))
                {
                    throw new ArgumentException($"{columns[6]} cannot be converted to int");
                }

                if (!(Int32.TryParse(columns[7], out int combined)))
                {
                    throw new ArgumentException($"{columns[7]} cannot be converted to int");
                }

                // deferred execution 
                yield return new Car
                {
                    Year = year,
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = displacement,
                    Cylinders = cylinder,
                    City = city,
                    Highway = highway,
                    Combined = combined
                };
            }
        }
    }
}


////var query = cars.OrderByDescending(c => c.Combined)
////                .ThenBy(c => c.Name); // secondary sort if there is a tie

//// make sure to filter before ordering
//var query =
//    from car in cars
//    where car.Manufacturer == "BMW" && car.Year == 2016
//    orderby car.Combined descending, car.Name ascending
//    select new
//    {
//        car.Manufacturer,
//        car.Name, 
//        car.Combined
//    }; // Manufactuer = car.Manufacturer   each property name will now become a propety name. 

//// same as the query syntax above 
//var result = cars.Select(c => new { c.Manufacturer, c.Name, c.Combined });// returns objects of  those properties. 

////don't need ascending as it is the default but showing off the keyword. 
//var query2 = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
//    .OrderByDescending(c => c.Combined)
//    .ThenBy(c => c.Name)
//    .Select(c => c);
////^ same results only a different way 

//// .First()  single a single no deferred execution. 
////var top = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
////    .OrderByDescending(c => c.Combined)
////    .ThenBy(c => c.Name)
////    .Select(c => c)
////    //.First(); //could also do the following 
////    
//// Annoymous typed object doesn't need a class. 
//var anon = new
//{
//    Name = "Scott"
//};
//// anon.Name;  

////string name = "Scott"
////IEnumerable<char> characters = "Scott"

////SelectMany in Action  flattens a collection of collections into a single collection 
//var selectMany = cars.Select(c => c.Name)
//                .OrderBy(c => c);




//// likely the previous version with filter first  is better for efficiency. 
//var top = cars
//    .OrderByDescending(c => c.Combined)
//    .ThenBy(c => c.Name)
//    .Select(c => c)
//    //.First(); //could also do the following // First can fail with an exception if no item matches 
//    //.First(c => c.Manufacturer == "BMW" && c.Year == 2016);
//    .FirstOrDefault(c => c.Manufacturer == "BMW" && c.Year == 2016);//this will result in a null value 

//if(top != null)
//     Console.WriteLine(top.Name);// only print if something came back from the query 
//// . Any   . All  returns true once it finds one that is true = Any and  returns once it finds one that doesn't match = All 
////. Conatins 
////var result = cars.All(c => c.Manufacturer.Contains("Ford"));
//Console.WriteLine(result);

//foreach ( var car in query.Take(10))
//{
//    Console.WriteLine($"{car.Name} : {car.Combined}");
//}