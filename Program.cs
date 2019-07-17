using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maximumToysSolution
{
    class Program
    {
        static int maximumToys(int[] prices, int k)
        {
            //only using a List because it comes with its own sort function 
            List<int> toys = new List<int>();
            foreach(int price in prices)
            {
                toys.Add(price);
            }
            //now sort the list 
            toys.Sort();
            //now that the items are sorted I can go through 
            int toysBought = 0; 
            foreach(int toy in toys)
            {
                // if k - toy is less than 0 we don't have enough to purhcase it. 
                if((k - toy) >= 0)
                {
                    //purchase the toy
                    k -= toy;
                    //increase toys bought 
                    toysBought += 1; 
                }
            }

            /*
             Sorted lists allows us to actually solve this problem really quickly  because we start off at the lowest end and buy up as many 
             toys as we possibly can  until we run out of money. With an unsorted list we would require much more time to solve this problem. 

             
             */
            return toysBought; 

        }
        static void Main(string[] args)
        {
            int[] sample = { 1, 12, 5, 111, 200, 1000, 10 };
            int k = 50;
            Console.WriteLine(maximumToys(sample, k));
        }

        

    }
}
