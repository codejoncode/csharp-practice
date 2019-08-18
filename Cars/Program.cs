using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Xml.Linq;

namespace Cars
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateXml();
            QueryXml();
        }

        private static void QueryXml()
        {
            var document = XDocument.Load("fuel.xml");

            //document.Element("Cars").Element("Car").Attribute("Manfacturer").Equals()
            //if nothing exists or Attribute doesn't exist it will throw an expection. 
            var query =
                from element in document.Element("Cars").Elements("Car")
                where element.Attribute("Manufacturer").Value == "BMW"
                select element.Attribute("Name").Value;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        
        }

        private static void CreateXml ()
        {
            var records = ProcessCars("fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars",
                from record in records
                select new XElement("Car",
                                new XAttribute("Name", record.Name),
                                new XAttribute("Combined", record.Combined),
                                new XAttribute("Manufacturer", record.Manufacturer))
                );
            document.Add(cars);
            document.Save("fuel.xml");
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
    public class CarStatistics
    {
        public int Max { get; set; }
        public int Min { get; set; }
        public double Average { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }

        public CarStatistics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }
        public CarStatistics Accumulate(Car car)
        {
            Total += car.Combined;
            Count += 1;
            Max = Math.Max(Max, car.Combined);
            Min = Math.Min(Min, car.Combined);
             

            return this;
        }

        public CarStatistics Compute()
        {
            Average = Total / Count; 
            return this;
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

//// grouping data
////var query =
////    from car in cars
////    group car by car.Manufacturer.ToUpper()
////    //lost car variable  it has been grouped can't use a orderby 
////    into manufactuer
////    orderby manufactuer.Key
////    select manufactuer;
////Group join 
////var query =
////    from manufacturer in manufacturers
////    join car in cars on manufacturer.Name
////                  equals car.Manufacturer
////        ///car is no longer available manufacturer is 
////        into carGroup
////    orderby manufacturer.Name
////    // projection 
////    select new
////    {
////        Manufacturer = manufacturer,
////        Cars = carGroup
////    };

////foreach (var group in query)
////{
////    Console.WriteLine($"{group.Manufacturer.Name} : {group.Manufacturer.Headquarters}");
////    foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
////    {
////        Console.WriteLine($"\t{car.Name} : {car.Combined}");
////    }
////}

///**
// *Want to fix issue where Chevy is listed multiple types because of upper and lower case spellings. 
// */


////var query2 =
////    cars.GroupBy(c => c.Manufacturer.ToUpper())
////         .OrderBy(g => g.Key);

////var query2 =
////    manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) =>
////         new
////         {
////             Manufacturer = m,
////             Cars = g
////         })
////    .OrderBy(m => m.Manufacturer.Name);

////var query3 =
////    //manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) =>
////    cars.GroupJoin(manufacturers, c => c.Manufacturer, m => m.Name, (g, m) =>
////     new
////     {
////         Manufacturer = m,
////         Cars = g
////     })
////    .OrderBy(g => g.Cars.Name);
////// order by country  top 3 cars by efficiency 
////var answer =
////    from manufacturer in manufacturers
////    join car in cars on manufacturer.Name equals car.Manufacturer
////        into carGroup
////    select new
////    {
////        Manufacturer = manufacturer,
////        Cars = carGroup
////    } into result
////    group result by result.Manufacturer.Headquarters; 

////var answer2  =
////    manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) =>
////         new
////         {
////             Manufacturer = m,
////             Cars = g
////         })
////    .GroupBy(m => m.Manufacturer.Headquarters);



////foreach (var group in answer2)
////{
////    Console.WriteLine($"{group.Key} : ");
////    foreach (var car in group.SelectMany(g => g.Cars)
////        .OrderByDescending(c => c.Combined).Take(3))
////    {
////        Console.WriteLine($"\t{car.Name} : {car.Combined}");
////    }
////}
//// Statistics for each  Manufacturer 
////var query =
////    from car in cars
////    group car by car.Manufacturer into carGroup
////    select new
////    {
////        Name = carGroup.Key,
////        Max = carGroup.Max(c => c.Combined),
////        Min = carGroup.Min(c => c.Combined),
////        Avg = carGroup.Average(c => c.Combined)
////    };
////this one orders by the max of each manufacturer first then 
//var query =
//    from car in cars
//    group car by car.Manufacturer into carGroup
//    select new
//    {
//        Name = carGroup.Key,
//        Max = carGroup.Max(c => c.Combined),
//        Min = carGroup.Min(c => c.Combined),
//        Avg = carGroup.Average(c => c.Combined)
//    } into result
//    orderby result.Max descending
//    select result;

//var query2 =

//    cars.GroupBy(c => c.Manufacturer)
//        .Select(g =>
//        {
//            // accumulator 
//            var results = g.Aggregate(new CarStatistics(),
//                                        (acc, c) => acc.Accumulate(c), // invoked on each element
//                                        acc => acc.Compute()); // done at the end 
//            return new
//            {
//                Name = g.Key,
//                Avg = results.Average,
//                results.Max,
//                results.Min
//            };
//        })
//        .OrderByDescending(c => c.Max);


//foreach (var result in query2)
//{
//    Console.WriteLine($"{result.Name}");
//    Console.WriteLine($"\t Max: {result.Max}");
//    Console.WriteLine($"\t Min: {result.Min}");
//    Console.WriteLine($"\t Avg: {result.Avg}");
//}

//foreach (var group in query)
//{
//    Console.WriteLine($"{group.Manufacturer.Name} : {group.Manufacturer.Headquarters}");
//    foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
//    {
//        Console.WriteLine($"\t{car.Name} : {car.Combined}");
//    }
//}
//foreach (var group in query2)
//{
//    Console.WriteLine(group.Key);
//    foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
//    {
//        Console.WriteLine($"\t{car.Name} : {car.Combined}");
//    }
//}
//var query =
//    from car in cars
//        //this is like a inner join in SQL
//    join manufacturer in manufacturers
//        on car.Manufacturer equals manufacturer.Name
//    orderby car.Combined descending, car.Name ascending
//    select new
//    {
//        manufacturer.Headquarters,
//        car.Name,
//        car.Combined
//    };

//var query2 =
//    from car in cars
//    join manufacturer in manufacturers
//        on new { car.Manufacturer, car.Year }
//           equals
//           new { Manufacturer = manufacturer.Name, manufacturer.Year }
//    orderby car.Combined descending, car.Name ascending
//    select new
//    {
//        manufacturer.Headquarters,
//        car.Name,
//        car.Combined
//    };

////method syntax
//var query3 =
//    //smaller sequence should come first
//    cars.Join(manufacturers,
//              c => c.Manufacturer,
//              m => m.Name, (c, m) => new
//              {
//                  m.Headquarters,
//                  c.Name,
//                  c.Combined
//              })
//        .OrderByDescending(c => c.Combined)
//        .ThenBy(c => c.Name);

//var query4 =
//    //smaller sequence should come first
//    cars.Join(manufacturers,
//              c => c.Manufacturer,
//              m => m.Name, (c, m) => new
//              {
//                  Car = c, 
//                  Manufacturer = m
//              })
//        .OrderByDescending(c => c.Car.Combined)
//        .ThenBy(c => c.Car.Name)
//        .Select(c => new
//        {
//            c.Manufacturer.Headquarters,
//            c.Car.Name,
//            c.Car.Combined
//        });
//The above is doing the same thing only it provides a different type of object with 3 properties 
/**
 *Headquarters, Name, Combined
 * The first part creates properties Car and Manufactuer and assigns the entire object as the properties value.
 * Then the second one takes only the desired data selects and returns it. 
 * The first one is more efficient than the second. 
 */


//foreach (var car in query.Take(10))
//{
//    Console.WriteLine($"{car.Headquarters} {car.Name} {car.Combined}");
//}
//Console.WriteLine("\n\n");

//foreach (var car in query2.Take(10))
//{
//    Console.WriteLine($"{car.Headquarters} {car.Name} {car.Combined}");
//}

//Console.WriteLine("\n\n");

//foreach (var car in query2.Take(10))
//{
//    Console.WriteLine($"{car.Headquarters} {car.Name} {car.Combined}");
//}

//var cars = ProcessCars("fuel.csv");
//var manufacturers = ProcessManufacturers("manufacturers.csv");

//var records = ProcessCars("fuel.csv");

//var document = new XDocument();

//var cars = new XElement("Cars");
//<Car>
//   <Name> 4C</Name >

//   <Combined> 28 </Combined >
//</Car >
//foreach (var record in records)
//{
//    var car = new XElement("Car");
//    var name = new XElement("Name", record.Name);
//    var combined = new XElement("Combined", record.Combined);

//    car.Add(name);
//    car.Add(combined);

//    cars.Add(car);
//}


// <Car Name="4C" Combined="28" />
//foreach (var record in records)
//{
//    var car = new XElement("Car");
//    var name = new XAttribute("Name", record.Name);
//    var combined = new XAttribute("Combined", record.Combined);

//    car.Add(name);
//    car.Add(combined);

//    cars.Add(car);
//}
// <Car Name="4C" Combined="28" />
//foreach (var record in records)
//{

//    var name = new XAttribute("Name", record.Name);
//    var combined = new XAttribute("Combined", record.Combined);
//    var car = new XElement("Car", name, combined, new XAttribute("Manufacturer", record.Manufacturer));
//    /// could also place new Xattribute("name", record.Name) inside of the car XElement;
//    /// 

//    cars.Add(car);
//}
//gets rid of the loop 
//var cars = new XElement("Cars");
//var elements =
//    from record in records
//    select new XElement("Car",
//                    new XAttribute("Name", record.Name),
//                    new XAttribute("Combined", record.Combined),
//                    new XAttribute("Manufacturer", record.Manufacturer));
//cars.Add(elements);

// functional construction. 
// no need for cars.Add(elements)
//var cars = new XElement("Cars",
//    from record in records
//    select new XElement("Car",
//                    new XAttribute("Name", record.Name),
//                    new XAttribute("Combined", record.Combined),
//                    new XAttribute("Manufacturer", record.Manufacturer))
//    );

//document.Add(cars);
//document.Save("fuel.xml");