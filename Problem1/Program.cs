using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{
    public class Statistics
    {

        public List<int> Values { get; private set; }
        public AllStats CompleteStats { get; private set; }

        public Statistics()
        {
            Values = new List<int>();
            CompleteStats = new AllStats();
        }
        /// <summary>
        /// Calculate the truncated mean, Median Mode and sample standard deviation. 
        /// also population standard deviation. 
        /// </summary>
        /// 
        public void AddValue (int value)
        {
            Values.Add(value);
        }
        /// <summary>
        /// So this takes teh values and sorts teh
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="discardedValue"></param>
        /// <returns></returns>
        public AllStats Calculate(int discardedValue)
        {
            //Convert the values into an enumerable of doubles. 
            IEnumerable<double> doubles = Values.Select(value => Convert.ToDouble(value));
            double[] doubleArray = doubles.ToArray();

            //Sort the doubles 
            Array.Sort(doubleArray);

            List<int> modes = Modes(Values);

            double median = Median(doubleArray);

            double truncatedMean = Math.Round(TruncatedMean(doubleArray, discardedValue), 2);

            double sampleStandardDeviation = Math.Round(StandardDeviation(doubleArray, true), 2);
            double populationStandardDeviation = Math.Round(StandardDeviation(doubleArray, false), 2);

            CompleteStats.TruncatedMean = truncatedMean.ToString();
            CompleteStats.Median = median.ToString();
            CompleteStats.Mode = string.Join(" ", modes.ConvertAll(i => i.ToString()));
            CompleteStats.SSD = sampleStandardDeviation.ToString();
            CompleteStats.PSD = populationStandardDeviation.ToString();

            return CompleteStats;
        }
        
        public AllStats Calculate<T>(double discardFraction)
        {
            //Convert the values into an enumerable of doubles. 
            IEnumerable<double> doubles = Values.Select(value => Convert.ToDouble(value));
            double[] doubleArray = doubles.ToArray();

            //Sort the doubles 
            Array.Sort(doubleArray);

            List<int> modes = Modes(Values);

            double median = Median(doubleArray);
            double truncatedMean = Math.Round(TruncatedMean(doubleArray, discardFraction),2);

            double sampleStandardDeviation = Math.Round(StandardDeviation(doubleArray, true),2);
            double populationStandardDeviation = Math.Round(StandardDeviation(doubleArray, false),2);

            CompleteStats.TruncatedMean = truncatedMean.ToString();
            CompleteStats.Median = median.ToString();
            CompleteStats.Mode = string.Join(" ", modes.ConvertAll(i => i.ToString()));
            CompleteStats.SSD = sampleStandardDeviation.ToString();
            CompleteStats.PSD = populationStandardDeviation.ToString();

            return CompleteStats;
        }
        /// <summary>
        /// If isRegular is true calculate regular standard deviation if flase calculate
        /// population standard deviation.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isRegular"></param>
        /// <returns>double</returns>
        public double StandardDeviation(double[] data, bool asSample)
        {
            var total = 0.0; 
            foreach(var num in data)
            {
                total += num;
            }

            double mean = total / data.Length;
            var squares_query = from double value in data
                                select (value - mean) * (value - mean);

            double sum_of_squares = squares_query.Sum();

            if (asSample)
            {
                return Math.Sqrt(sum_of_squares / data.Length - 1);
            }
            else
            {
                return Math.Sqrt(sum_of_squares / data.Length);
            }
        }

        public List<int> FindMode(int[] data)
        {
            Dictionary<int, int> cache = new Dictionary<int, int>();
            HashSet<int> hashSet = new HashSet<int>();
            int max = 0;
            foreach(int num in data)
            {
                if (cache.ContainsKey(num))
                {
                    cache[num] += 1;
                    if (cache[num] > max)
                    {
                        max = cache[num];

                    }
                }
                else
                {
                    cache[num] = 1; 
                }
                hashSet.Add(num);
            }

            List<int> returning = new List<int>();
            
            foreach(int num in hashSet)
            {
                if (cache[num] == max)
                {
                    returning.Add(num);
                }
            }

            return returning;
        }

        public static List<int> Modes (List<int> values)
        {
            // Make a dictionary to hold value counts 
            Dictionary<int, int> counts = new Dictionary<int, int>();


            // Count the values. 
            foreach ( int value in values)
            {
                if (!counts.ContainsKey(value))
                {
                    counts.Add(value, 1);
                }
                else
                {
                    counts[value]++;
                }
            }

            //Find the largest count. 
            int largestCount = counts.Values.Max();

            //Find the value(s) with that count 
            List<int> modes = new List<int>();
            foreach (KeyValuePair<int, int> pair in counts)
            {
                if (pair.Value == largestCount)
                {
                    modes.Add(pair.Key);
                }
            }
            return modes; 
        }

        public int[] SortData(int[] data)
        {
            List<int> newList = new List<int>();

            foreach (var num in data)
            {
                newList.Add(num);
            }
            newList.Sort();

            int[] returningData = new int[newList.Count];
            for (int index = 0; index < returningData.Length; index++)
            {
                returningData[index] = newList[index];
            }

            return returningData;
        }

        public double TruncatedMean(int[] data, int iNumberToRemove)
        {
            int[] dataToCalculate = RemoveFromArray(data, iNumberToRemove);
            int total = 0;
            foreach (var num in dataToCalculate)
            {
                total += num;
            }

            double returnValue = total / dataToCalculate.Length;
            return returnValue;
        }
        /// <summary>
        /// Return the truncated mean of an IEnumberable of numbers. 
        /// Set discardNumber to the number of values to discard at the 
        /// discard the 5 largest and smallest values. 
        /// By accepting IEnumerable you can work with arrays and lists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="discardNumber"></param>
        /// <returns>double</returns>
        /// 
        // Has a generic type parameter T between its name and its parmater list. 
        // Both arrays and lists implement IEnumerable this means that the method applies to both arrays and lists. 

        public double TruncatedMean (double[] doubleArray, int discardNumber)
        {
            //Convert the values into an enumerable of doubles. 
            //IEnumerable<double> doubles = values.Select(value => Convert.ToDouble(value));
            //double[] doubleArray = doubles.ToArray();

            ////Sort the doubles 
            //Array.Sort(doubleArray);

            //Find the values that we want to use. 
            int minIndex = discardNumber;
            //take length minus 1 for zero based index then discard amount not to worry about
            int maxIndex = doubleArray.Length - 1 - discardNumber;

            // Copy the desired items into a new array. 
            int numRemaining = maxIndex - minIndex + 1;
            double[] remainingItems = new double[numRemaining];
            Array.Copy(doubleArray, minIndex, remainingItems, 0, numRemaining);

            //Calculate and return the truncated mean. 
            return remainingItems.Average(); 
        }

        /*
         * This extension method takes as its second parameter, the number of largest and smallest values that it should discard.
         * The following overloaded version of the method takes a discard fraction as a parmater instead: 
         */
         /// <summary>
         /// REturn the truncated mean of an IEnumberable of numbers. 
         /// Set discardFraction to the fraction of values to discard at the 
         /// top and bottom. For example, set discardFraction = 0.05 to 
         /// discard the 5% largest and smallest values. 
         /// 
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="values"></param>
         /// <param name="discardFraction"></param>
         /// <returns>double</returns>
         public double TruncatedMean(double[] values, double discardFraction)
        {
            //Calculate the number of items to remove at the top and bottom. 
            int discardNumber = (int) (values.Length * discardFraction);
            return TruncatedMean(values, discardNumber);
        }

        public int[] RemoveFromArray(int[] data, int iNumberToRemove)
        {
            List<int> newData = new List<int>();
            int count = 0;
            for (var i = 0; i < data.Length - iNumberToRemove; i++)
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
            foreach (var num in newData)
            {
                returningData[index] = num;
                index += 1;
            }

            return returningData;

        }


        public double Median(double[] doubleArray)
        {
            //Convert into an enumerable of doubles. 
            //IEnumerable<double> doubles = values.Select(value => Convert.ToDouble(value));
            //double[] doubleArray = doubles.ToArray();

            ////Sort the doubles 
            //Array.Sort(doubleArray);

            //Calculate and return the median. 
            int numValues = doubleArray.Length; 
            if(numValues %2 == 1)
            {
                //There are an odd number of values. 
                // Return the middle one. 
                return doubleArray[numValues / 2];
            }

            // Return the mean of the two middle values. 
            double value1 = doubleArray[numValues / 2 - 1];
            double value2 = doubleArray[numValues / 2];
            return (value1 + value2) / 2.0;
        }

       

        

        static public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        static void Main(string[] args)
        {
            //amount of data to grab 
            //int iNumberToRandomsToGenerate = 10;
            Statistics statistics = new Statistics();

            //int[] data = statistics.RemoveFromArray(new int[] { 1, 1, 3, 5, 7, 7, 9 }, 2);
            int[] unsorted = new int[] { 9, 7, 1, 3, 1, 7, 5, 7 };
            foreach(var value in unsorted)
            {
                statistics.AddValue(value);
            }
            AllStats completeStats = statistics.Calculate(2);
            Console.WriteLine($"Trucated Mean {completeStats.TruncatedMean}");
            Console.WriteLine($"Mode {completeStats.Mode}");
            Console.WriteLine($"Mean {completeStats.Median}");
            Console.WriteLine($"Sample Standard Dev {completeStats.SSD}");
            Console.WriteLine($"Population Standard Dev {completeStats.PSD}");
            //int[] sortedData = statistics.SortData(unsorted);
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

            //foreach (var num in sortedData)
            //{
            //    Console.Write($"{num} ");
            //}
        }
    }
}
