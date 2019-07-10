using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strong_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             https://www.hackerrank.com/challenges/strong-password/problem
             */
            minimumNumber(3, "Ab1");
            minimumNumber(11, "#HackerRank");
        }

        static int minimumNumber(int n, string password)
        {
            // Return the minimum number of characters to make the password strong
            string numbers = "0123456789";
            string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string specialCharacters = "!@#$%^&*()-+";

            int passwordStrength = 0;
            // length 
            if (n >= 6)
            {
                passwordStrength += 1; 
            }
            bool specialDone = false;
            bool lowerDone = false;
            bool upperDone = false;
            bool numbersDone = false; 

            foreach(char character in password)
            {
                if(!specialDone)
                {
                    if (specialCharacters.Contains(character))
                    {
                        specialDone = true;
                        passwordStrength += 1; 
                    }
                }
                if (!lowerDone)
                {
                    if(lowerCase.Contains(character))
                    {
                        lowerDone = true;
                        passwordStrength += 1; 
                    }
                }
                if (!upperDone)
                {
                    if(upperCase.Contains(character))
                    {
                        upperDone = true;
                        passwordStrength += 1; 
                    }
                }

                if (!numbersDone)
                {
                    if(numbers.Contains(character))
                    {
                        numbersDone = true;
                        passwordStrength += 1; 
                    }
                }
                if (numbersDone && upperDone && lowerDone && specialDone)
                {
                    break; 
                }
            }

            if(n < 6)
            {
                return 6 - n;
            }
            else
            {
                return 5 - passwordStrength;
            }

            Console.WriteLine(passwordStrength);
            return passwordStrength;

        }
    }
}
