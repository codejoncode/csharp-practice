using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort_Counting_Inversions
{
    class Program
    {

        static void MergeSort(int[] data, int left, int right, ref long inversions)
        {
            
            if (left < right)
            {
                //inversions++;
                int middle = (left + right) / 2;
                MergeSort(data, left, middle, ref inversions);
                MergeSort(data, middle + 1, right, ref inversions);

                Merge(data, left, middle, right, ref inversions);

            }
        }

        static void Merge(int[] data, int left, int middle, int right, ref long inversions)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];
            Array.Copy(data, left, leftArray, 0, middle - left + 1);
            Array.Copy(data, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;


            for (int k = left; k < right + 1; k++)
            {


                if (i == leftArray.Length)
                {
                    data[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
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
                    inversions += leftArray.Length - i;
                } 
            }
        }
        static long countInversions(int [] arr)
        {
            long inversions = 0;
            MergeSort(arr, 0, arr.Length - 1, ref inversions);

            return inversions; 
        }
        static void Main(string[] args)
        {
            int[] sample = { 2,1,3,1,2 };
            Console.WriteLine(  countInversions(sample ));
            int[] sample2 = { 1,1,1,2,2};
            Console.WriteLine(countInversions(sample2));
            int[] sample3 = { 62935, 82200, 877141, 585771, 619073, 183328, 809452, 189197, 41883, 777611, 360495, 295099, 198393, 308583, 537954, 11054, 515803, 403848 };
            Console.WriteLine(countInversions(sample3));

            for(int index = 0; index < sample3.Length; index++)
            {
                Console.Write(sample3[index]);
                Console.Write(" ");
            }
        }
    }
}
