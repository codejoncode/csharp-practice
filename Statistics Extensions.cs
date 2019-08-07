using System;
using System.Collections.Generic;

namespace StatisticsExtensions
{
    class Statistics
    {
        public double trucatedMean(int[] array, int remove)
        {
            List<int> lst = new List<int>();
            foreach(var integer in array)
            {
                lst.Add(integer);
            }

            lst.Sort();



        }
        static void Main(string[] args)
        {
            
        }
    }
}
