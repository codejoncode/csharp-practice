using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book
    {
        // fields/ properties 
        List<double> Grades { get; set; }
        public string Name { get; set; }


        //Constructor 
        public Book ()
        {
            //without setting Grades  Grades will be a null value and produce an error when trying to add to it. 
            Grades = new List<double>();

        }

        public Book ( string name)
        {
            Grades = new List<double>();
            this.Name = name; 
        }
        //Methods 
        /// <summary>
        /// Add a grade to the List Grades on the class. 
        /// </summary>
        /// <param name="grade"></param>
        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                Grades.Add(grade);
            } 
            else
            {
                Console.WriteLine($"The value {grade} does not meet the requirements  0 - 100 inclusive");
            }
        }

        public double AccessGrade(int assignmentNumber)
        {
            //take the assignment number and minus it by one.  
            if(assignmentNumber > 0)
            {
                return Grades[assignmentNumber - 1];
            }

            Console.WriteLine("The assignment could not be found. Assignments are order 1 to the max number of assignments");
            return -100;
        }

        public double ComputeAverage()
        {
            double results = 0.0;
            foreach(var grade in Grades)
            {
                results += grade; 
            }

            if(results > 0)
            {
                results /= Grades.Count;
            }

            return results; 
        }

        public void ShowStatistics ()
        {
            var minimum = 100.0;
            var maximum = 0.0;
            var toBecomeAverage = 0.0;

            foreach(var grade in Grades)
            {
                minimum = Math.Min(grade, minimum);
                maximum = Math.Max(grade, maximum);
                toBecomeAverage += grade; 
            }

            toBecomeAverage /= Grades.Count;

            Console.WriteLine($"The minimum grade : {minimum}\n The maximum grade : {maximum}\n The average grade : {toBecomeAverage}");


        }
    }
}
