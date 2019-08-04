using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book
    {
        // fields/ properties 
        List<double> Grades { get; set; }
        public string Name { get; private set; }

        public double Minimum { get; private set; }
        public double Maximum { get; private set; }
        public double Average { get; private set; }

        //Constructor 
        public Book () : this("No Name Provided")
        {

        }

        public Book ( string name)
        {
            Grades = new List<double>();
            this.Name = name;
            this.Minimum = 0.0;
            this.Maximum = 0.0;
            this.Average = 0.0;
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
                this.ComputeStatistics();
            } 
            else
            {
                Console.WriteLine($"The value {grade} does not meet the requirements  0 - 100 inclusive");
            }
        }
        /// <summary>
        /// Access the grade based off the assignment number. 
        /// Will subtract one from number provided so 1 = 0 index. 
        /// </summary>
        /// <param name="assignmentNumber"></param>
        /// <returns>double</returns>
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
        /// <summary>
        /// Compute the average grade using the Grades List<double> property.
        /// </summary>
        /// <returns>double rounded to two decimal places</returns>
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

            return Math.Round(results, 2); 
        }
        /// <summary>
        /// Compute the Statistics for the Book instance. usually ran after adding to the 
        /// Book but can be called on its own. 
        /// </summary>
        public void ComputeStatistics()
        {
            var minimum = 100.0;
            var maximum = 0.0;
            var toBecomeAverage = 0.0;

            foreach (var grade in Grades)
            {
                minimum = Math.Min(grade, minimum);
                maximum = Math.Max(grade, maximum);
                toBecomeAverage += grade;
            }

            toBecomeAverage /= Grades.Count;

            this.Maximum = maximum;
            this.Minimum = minimum;
            this.Average = Math.Round(toBecomeAverage, 2);
        }
        /// <summary>
        /// ShowStatistics will print out the stats but will also 
        /// return an array that has the minimum in the first slot maximum in the second 
        /// and average in the third slot. 
        /// </summary>
        /// <returns></returns>
        public double[] ShowStatistics ()
        {
            if(Grades.Count == 0)
            {
                return new double[] { 0, 0, 0 };
            }
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
            var returning = new double[] { minimum, maximum, Math.Round(toBecomeAverage,2) };
            return returning; 
        }
        /// <summary>
        /// Updates the name  property on Book instance. 
        /// </summary>
        /// <param name="name"></param>
        public void UpdateName(string name)
        {
            if (name.Length > 0)
            {
                this.Name = name; 
            }
        }
    }
}
