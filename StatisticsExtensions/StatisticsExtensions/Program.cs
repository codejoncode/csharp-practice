using System;
using System.Collections.Generic;

namespace StatisticsExtensions
{
    public class Statistics
    {
        /// <summary>
        /// Calculate the truncated mean, Median Mode and sample standard deviation. 
        /// also population standard deviation. 
        /// </summary>
        public void Calculate (int[] data)
        {
            
        }

        public int [] SortData (int[] data)
        {
            List<int> newList = new List<int>();

            foreach( var num in data)
            {
                newList.Add(num);
            }
            newList.Sort();

            int[] returningData = new int[newList.Count];
            for(int index = 0; index < returningData.Length; index++)
            {
                returningData[index] = newList[index];
            }

            return returningData; 
        }

        public double TruncatedMean (int[] data, int iNumberToRemove)
        {
            int[] dataToCalculate = RemoveFromArray(data, iNumberToRemove);
            int total = 0;
            foreach(var num in dataToCalculate)
            {
                total += num;
            }

            double returnValue = total / dataToCalculate.Length;
            return returnValue;

        }

        public int[] RemoveFromArray (int[] data, int iNumberToRemove)
        {
            List<int> newData = new List<int>();
            int count = 0; 
            for(var i = 0; i< data.Length-iNumberToRemove; i++)
            {
                if (count < iNumberToRemove)
                {
                    count += 1; 
                }
                else
                {
                    newData.Add(data[i]);
                }
            }

            int[] returningData = new int[newData.Count];

            int index = 0; 
            foreach(var num in newData)
            {
                returningData[index] = num;
                index += 1; 
            }

            return returningData;

        }
            

        public void Median ()
        {

        }

        public void Mode ()
        {

        }

        public void SampleStandardDeviation ()
        {

        }

        public void PopulationStandardDeviation ()
        {

        }

        static public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        static void Main(string[] args)
        {
            //amount of data to grab 
            int iNumberToRandomsToGenerate = 10;
            Statistics statistics = new Statistics();

            int[] data = statistics.RemoveFromArray(new int[] { 1, 1, 3, 5, 7, 7, 9 }, 2);

            //int index = 0; 
            //while (index != iNumberToRandomsToGenerate)
            //{
            //    int iRandomNumber = RandomNumber(
            //        0,
            //        100);
            //    Console.WriteLine(iRandomNumber);
            //    data[index] = iRandomNumber;
            //    index += 1; 
            //}

            foreach(var num in data)
            {
                Console.Write($"{num} ");
            }
        }
    }
}
