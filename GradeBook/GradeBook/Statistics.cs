using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public Statistics() : this(0.0, 0.0, 0.0)
        {
            
        }
        public Statistics(double minimum, double maximum, double average)
        {
            Minimum = minimum;
            Maximum = maximum;
            Average = average;
        }

        public double Average { get; set; }
        public double Minimum { get; private set; }
        public double Maximum { get; private set; }
    }
}
