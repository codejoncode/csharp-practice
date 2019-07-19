using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void MergeSort(int[] data, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(data, left, middle);
                MergeSort(data, middle + 1, right);

                Merge(data, left, middle, right);
            }
            
        }

        static void Merge(int [] data, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];
            Array.Copy(data, left, leftArray, 0, middle - left + 1);
            Array.Copy(data, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for(int k = left; k < right + 1; k++)
            {
                if ( i == leftArray.Length)
                {
                    data[k] = rightArray[j];
                    j++;
                }
                else if ( j == rightArray.Length)
                {
                    data[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    data[k] = leftArray[i];
                    i++;
                }
                else
                {
                    data[k] = rightArray[j];
                    j++;
                }
            }

        }
        static void Main(string[] args)
        {
            int [] sample = { 5, 3, 1, 8, 9 , 4, 12};
            MergeSort(sample, 0, sample.Length-1);
            for (int i = 0; i < sample.Length; i++)
            {
                Console.WriteLine(sample[i]);
            }

        }
    }
}
