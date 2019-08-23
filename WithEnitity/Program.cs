using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WithEnitity;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            //nothing that is done in a team envoritment or production 
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
            //^^^^  just for this demo
            InsertData();
            QueryData();
            Func<int, int> squre = x => x * x;
            Expression<Func<int, int, int>> add = (x, y) => x + y;
            Console.WriteLine(add); // will actually output the code that was written. 

        }

        private static void QueryData()
        {
            var db = new CarDb();
            //db.Database.Log = Console.WriteLine;// will prove we are connecting to SQL Server.

            var query = from car in db.Cars
                        orderby car.Combined descending, car.Name ascending
                        select car;
            //foreach(var car in query.Take(10))
            //{
            //    Console.WriteLine($"{car.Name}: {car.Combined}");
            //}
            Console.WriteLine("\n");
            var query2 = db.Cars.OrderByDescending(c => c.Combined).ThenBy(c => c.Name).Take(10);
            //foreach (var car in query2)
            //{
            //    Console.WriteLine($"{car.Name}: {car.Combined}");
            //}
            // IQueryable does not have to execute code in memory  
            db.Database.Log = Console.WriteLine;
            var query3 =
                db.Cars.Where(c => c.Manufacturer == "BMW")
                       .OrderByDescending(c => c.Combined)
                       .ThenBy(c => c.Name)
                       .Take(10)
                       //.Select(c => new {  Name = c.Name.ToUpper() })
                       .ToList();



            Console.WriteLine(query3.Count());
            Func<int, int> square = x => x * x;
            Expression<Func<int, int, int>> add = (x, y) => x + y; // will only be a string 
            var result = add.Compile()(3, 5);// this code allows me to run the code held by the expression
                                             //strips away the expression 

            // could also do this 
            Func<int, int, int> addI = add.Compile();

            result = addI(3, 5);

            




            foreach (var car in query3)
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }


            var query4 =
                db.Cars.GroupBy(c => c.Manufacturer)
                  .Select(g => new
                  {
                      Name = g.Key,
                      Cars = g.OrderByDescending(c => c.Combined).Take(2)
                  });
            foreach (var group in query4)
            {
                Console.WriteLine(group.Name);
                foreach (var car in group.Cars)
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }

            //same above  below in query syntax 
            var query5 =
                from car in db.Cars
                group car by car.Manufacturer into manufacturer
                //lose access to car variable 
                select new
                {
                    Name = manufacturer.Key,
                    //Cars = manufacturer.OrderByDescending(c => c.Combined).Take(2)
                    Cars = (from car in manufacturer
                            orderby car.Combined descending
                            select car).Take(2)
                };
        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarDb();
            //db.Database.Log = Console.WriteLine;// will prove we are connecting to SQL Server.

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);//make note to insert the car
                }
                // this is where the insertion takes place 
                db.SaveChanges();
            }

        }

        private static List<Car> ProcessCars(string path)
        {

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
