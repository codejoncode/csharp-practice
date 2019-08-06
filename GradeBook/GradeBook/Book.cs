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
        public char Letter { get; private set; }


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
            this.Letter = 'A';
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
                throw new ArgumentException($"Invalid {nameof(grade)} {grade} does not meet the requirements  0 - 100 inclusive");
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

            throw new ArgumentException($"Invalid {nameof(assignmentNumber)} {assignmentNumber} does not exist in the grade list");
        }
        /// <summary>
        /// Compute the average grade using the Grades List<double> property.
        /// </summary>
        /// <returns>double rounded to two decimal places</returns>
        public double ComputeAverage()
        {
            _ = ComputeStatistics();
            return Average;
            
        }
        /// <summary>
        /// Compute the Statistics for the Book instance. usually ran after adding to the 
        /// Book but can be called on its own. 
        /// </summary>
        /// <returns>Statistics object</returns>
        public Statistics ComputeStatistics()
        {
            if(Grades.Count == 0)
            {
                return new Statistics();  
            }
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

            switch(this.Average)
            {
                case var d when d >= 90.0:
                    this.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    this.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    this.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    this.Letter = 'D';
                    break;
                default:
                    this.Letter = 'F';
                    break;
            }

            Statistics returning = new Statistics(this.Minimum, this.Maximum, this.Average, this.Letter);
            return returning; 
        }
        /// <summary>
        /// ShowStatistics will print out the stats but will also 
        /// return an array that has the minimum in the first slot maximum in the second 
        /// and average in the third slot. Calls ComputeStatistics whill does the calculations. 
        /// Console logs and returns. 
        /// </summary>
        /// <returns>array of length 3 with doubles minimum maximum average (in that order)</returns>
        public Statistics ShowStatistics ()
        {
            Statistics returning = this.ComputeStatistics();
            
            Console.WriteLine($"The minimum grade : {this.Minimum}\n The maximum grade : {this.Maximum}\n The average grade : {this.Average}\n The letter is {this.Letter}");
            //var returning = new double[] { this.Minimum, this.Maximum, this.Average };
            
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

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'a':
                    letter = 'A';
                    break;
                case 'b':
                    letter = 'B';
                    break;
                case 'c':
                    letter = 'C';
                    break;
                case 'd':
                    letter = 'D';
                    break;
                case 'f':
                    letter = 'F';
                    break;
                default:
                    throw new ArgumentException($"Invalid {nameof(letter)} {letter} is not an valid choice");
            }

            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
                default:
                    throw new ArgumentException($"Invalid {nameof(letter)} {letter} is not an valid choice");
            }
            
        }
    }
}
