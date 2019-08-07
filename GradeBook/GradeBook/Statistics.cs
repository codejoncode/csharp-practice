using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        //Fields 
        private char letter = 'A';
        // constructor
        public Statistics() : this(100.0, 0.0, 0.0, 'A')
        {

        }
        public Statistics(double minimum, double maximum, double average, char letter)
        {
            Minimum = minimum;
            Maximum = maximum;
            Average = average;
            Letter = letter;
            Total = 0;
            Count = 0;
        }
        // Properties 
        public double Average { get; private set; }
        public double Minimum { get; private set; }
        public double Maximum { get; private set; }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        Letter = 'A';
                        break;
                    case var d when d >= 80.0:
                        Letter = 'B';
                        break;
                    case var d when d >= 70.0:
                        Letter = 'C';
                        break;
                    case var d when d >= 60.0:
                        Letter = 'D';
                        break;
                    default:
                        Letter = 'F';
                        break;
                }

                return letter;
            }
            private set
            {
                letter = value;
            }

        }
        public double Total { get; private set; }
        public int Count { get; private set; }

        // Methods 
        public void AddToStatistics(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Total += grade;
                Count += 1;

                Maximum = Math.Max(grade, Maximum);
                Minimum = Math.Min(grade, Minimum);
                Average = Math.Round(Total / Count, 2);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} {grade} is not within the range of 0 to 100 inclusively.");
            }


        }

    }
}
