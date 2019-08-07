using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook
{
    
    //normally put delegate in a seperate file 
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public string Name { get; set; }
    }

    public interface IBook
    {
        //define a pure abstraction 
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public abstract event GradeAddedDelegate GradeAdded;
        // don't know what the implementation will be. Defined later. 
        public abstract void AddGrade(double grade);
        //Here is a method but a derived class will override this method
        public abstract Statistics GetStatistics(); 
    }

    public class InMemoryBook : Book
    {
        // fields/ properties 
        List<double> Grades { get; set; }
        //public string Name { get; private set; }

        public double Minimum { get; private set; }
        public double Maximum { get; private set; }
        public double Average { get; private set; }
        public char Letter { get; private set; }

        

        // Event 
        public override event GradeAddedDelegate GradeAdded; 


        //Constructor 
        public InMemoryBook () : this("No Name Provided")
        {

        }

        public InMemoryBook ( string name)
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
        /// YOu can only override  static or virtual methods from classes you inherit from. 
        /// </summary>
        /// <param name="grade"></param>
        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                Grades.Add(grade);
                if(GradeAdded != null)
                {
                    //object refernce is the sender
                    GradeAdded(this, new EventArgs());
                }
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
        public override Statistics GetStatistics ()
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

    public class DiskBook : InMemoryBook
    {
        /*
         * slight issue with this implemenation  when I update the name it changes teh book name thus it could write to a seperate file
         * one way is i could have a checker to see if the book has created a file by using a boolean   as long as no file has been created 
         * allow it to update the name. 
         */
        //property 
        public bool IsFileCreated { get; private set; }
        public Statistics Stats { get; private set; }


        // Event 
        public override event GradeAddedDelegate GradeAdded;

        public DiskBook()
        {
            IsFileCreated = false;
            Stats = new Statistics(); 
        }
        /// <summary>
        /// Temporary solution to avoid Updating a name with a file already created of course  we could also look up 
        /// how to change the file name if so and update the file name  but i wanted to acknowledge the difference in my own code 
        /// as compared to the instructors. 
        /// </summary>
        /// <param name="name"></param>
        public new void UpdateName(string name)
        {
            
            if (!IsFileCreated && name.Length > 0)
            {
                this.Name = name;
            } 
            else if (IsFileCreated)
            {
                throw new Exception("A file has already been created with this name so changing the name is forbidden");
            }
        }
        public override void AddGrade(double grade)
        {
            // add to a disk file 
            //same name as the book but with a .txt extension.
            Console.WriteLine($"{Name}.txt being created and {grade} being added");
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                IsFileCreated = true;
                Stats.AddToStatistics(grade);
                

            }//writer.Dispose();//does the same thing as .Close 
            //by using  writer.Dispose is called at the end  
        }

        public override Statistics GetStatistics()
        {
            /*
             * So  with Stats  the Letter Minimum Maximum and Average props are really no longer needed 
             *  
             */
            return Stats; 
        }

        public new double AccessGrade(int assignmentNumber)
        {
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                int count = 0;
                double returningValue = 0.0;
                while (line != null && count != assignmentNumber - 1)
                {
                    //count starts off at zero which is zero based so i subtract one from the assignment number 
                    var number = double.Parse(line);
                    if (count == assignmentNumber - 1)
                    {
                        returningValue = number;
                        break; 
                    }

                    line = reader.ReadLine();
                    count += 1; 
                }
                if (line == null)
                {
                    throw new ArgumentException($"Invalid {nameof(assignmentNumber)} this assignment does not exist {assignmentNumber}");
                }
                return returningValue; 
            }
        }

        /**
         * This is code for reading the file. I went in a different direction where I don't actually have to read the file since statstics is being placed 
         * as a property this makes collecting the the grades faster. I didn't use a grades field  so i saved memory
         * but there are drop offs how will i now access a certain grade?   well surely that method would have to be overriddne as well. 
         * var result = new Statistics(); 
         * using(var reader = File.OpenText($"{Name}.txt"))
         * {
         *    var line = reader.ReadLine();
         *    while (line != null)
         *    {
         *       var number = double.Parse(line);
         *       result.Add(number);
         *       line = reader.ReadLine();
         *    }
         * }
         * 
         */
    }
}
