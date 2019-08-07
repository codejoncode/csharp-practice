using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
        static void Main(string[] args)
        {

            //List<double> grades = new List<double>();
            // var grades = new List<double>();
            DiskBook book = new DiskBook();
            book.UpdateName("JonathanToFile");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;


            var grades = new List<double>() { 89.1, 90.5, 77.5 };
            //foreach(var grade in grades)
            //{
            //    book.AddGrade(grade);
            //}
            Console.WriteLine("Input a double  0.0 or greater using a decimal point or the letter q to quit");
            EnterGrades(book);
            var stats = book.GetStatistics();
            Console.WriteLine($"{stats.Average }\n  {stats.Maximum}\n {stats.Minimum}\n {stats.Letter}\n");
        }

        

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                var input = Console.ReadLine();
                double grade;
                if ("q".Equals(input))
                {
                    Console.WriteLine("Quitting the program");
                    break;
                }
                try
                {
                    grade = double.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"{input} is not a double");
                    continue;
                }

                try
                {
                    book.AddGrade(grade);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                // piece of code you want to execute 
                finally
                {
                    // also add this  \ close a file or clean things up when there has been an exception. 
                    Console.WriteLine("_________");
                }
            }
        }
    }
}
