using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public Statistics() : this(0.0, 0.0, 0.0, 'A')
        {
            
        }
        public Statistics(double minimum, double maximum, double average, char letter)
        {
            Minimum = minimum;
            Maximum = maximum;
            Average = average;
            Letter = Letter;
        }

        public double Average { get; set; }
        public double Minimum { get; private set; }
        public double Maximum { get; private set; }
        public char Letter { get; private set; }

    }
}
