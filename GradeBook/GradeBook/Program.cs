using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<double> grades = new List<double>();
            // var grades = new List<double>();
            Book book = new Book();
            

            var grades = new List<double>() {89.1, 90.5, 77.5};
            foreach(var grade in grades)
            {
                book.AddGrade(grade);
            }
            book.ShowStatistics();
            
            

            
        }
    }
}
