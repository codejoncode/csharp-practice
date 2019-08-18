using System;

namespace FindThePoint
{
    //https://www.hackerrank.com/challenges/find-point/problem
    class Program
    {
        static int[] FindPoint(int px, int py, int qx, int qy)
        {
            /*
             * Write your code here.
             */
            return new int[]
            {
                2 * qx - px,
                2 * qy - py
            };
            


        }

        static void Main(string[] args)
        {
            var result1 = FindPoint(0, 0, 1, 1);
            Console.WriteLine(string.Join(" ", result1));
            var result2 = FindPoint(1, 1, 2, 2);
            Console.WriteLine(string.Join(" ", result2));
        }
    }
}
