using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelCase
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             https://www.hackerrank.com/challenges/camelcase/problem

             */
            CamelCase("saveChangesInTheEditor");
        }
        //passes all tests 
        static int CamelCase(string s)
        {
            string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int count = 0; 
            foreach(char character in s)
            {
                if(upperCase.Contains(character))
                {
                    count++;
                }
            }
            Console.WriteLine(count + 1);
            return count + 1; 
        }
    }
}
