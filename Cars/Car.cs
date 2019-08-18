using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }

        //internal static Car ParseFromCsv(string line)
        //{
        //    var columns = line.Split(',');
            
        //    if(!(Int32.TryParse(columns[0], out int year)))
        //    {
        //        throw new ArgumentException($"{columns[0]} cannot be converted to int");
        //    }
        //    if (!(Double.TryParse(columns[3], out double displacement)))
        //    {
        //        throw new ArgumentException($"{columns[3]} cannot be converted to double");
        //    }

        //    if (!(Int32.TryParse(columns[4], out int cylinder)))
        //    {
        //        throw new ArgumentException($"{columns[4]} cannot be converted to int");
        //    }

        //    if (!(Int32.TryParse(columns[5], out int city)))
        //    {
        //        throw new ArgumentException($"{columns[5]} cannot be converted to int");
        //    }

        //    if (!(Int32.TryParse(columns[6], out int highway)))
        //    {
        //        throw new ArgumentException($"{columns[6]} cannot be converted to int");
        //    }

        //    if (!(Int32.TryParse(columns[7], out int combined)))
        //    {
        //        throw new ArgumentException($"{columns[7]} cannot be converted to int");
        //    }

            


        //    return new Car
        //    {
        //        Year = year,
        //        Manufacturer = columns[1],
        //        Name = columns[2],
        //        Displacement = displacement,
        //        Cylinders = cylinder,
        //        City = city,
        //        Highway = highway,
        //        Combined = combined
        //    };
        //}
    }
}
