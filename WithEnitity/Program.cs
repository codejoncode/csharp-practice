using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //QueryData();
        }

        private static void QueryData()
        {
            throw new NotImplementedException();
        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarDb();

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
