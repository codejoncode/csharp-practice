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
            minimumNumber(4, "4700");
        }

        static int minimumNumber(int n, string password)
        {
            // Return the minimum number of characters to make the password strong
            string numbers = "0123456789";
            string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string specialCharacters = "!@#$%^&*()-+";
            //returning this 
            int passwordStrength = 0;
            //using these to count once and only once 
            bool specialDone = false;
            bool lowerDone = false;
            bool upperDone = false;
            bool numbersDone = false;
            //characters needed 
            int charactersNeeded = n < 6 ? 6 - n : 0;
            // so we need more characters if its less than 0 if equal or zero we neeed no characters length wise

            foreach (char character in password)
            {
                if (specialCharacters.Contains(character))
                {
                    if (!specialDone)
                    {
                        specialDone = true;
                        passwordStrength += 1;
                    }
                }
                else if (lowerCase.Contains(character))
                {

                    if (!lowerDone)
                    {
                        lowerDone = true;
                        passwordStrength += 1;
                    }
                }
                else if (upperCase.Contains(character))
                {
                    if (!upperDone)
                    {
                        upperDone = true;
                        passwordStrength += 1;
                    }
                }

                else if (numbers.Contains(character))
                {
                    if (!numbersDone)
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
            Console.WriteLine($"This is the passwordStrength before returning {passwordStrength}");
            if (n < 6)
            {
                if (passwordStrength == 4)
                {
                    Console.WriteLine($"{charactersNeeded} if block 85");
                    return charactersNeeded;
                } 
                else if ( passwordStrength != 4)
                {
                    int makeStronger = 4 - passwordStrength;
                    if (charactersNeeded > makeStronger)
                    {
                        Console.WriteLine($"{charactersNeeded} if block 93");
                        return charactersNeeded;
                    }
                    else if ( charactersNeeded < makeStronger)
                    {
                        Console.WriteLine($"{makeStronger} else if 98");
                        return makeStronger;
                    }
                    else
                    {
                        Console.WriteLine($"{charactersNeeded} else block 102");
                        return makeStronger;
                    }
                }
                
            }
            else
            {
                Console.WriteLine($"{4 - passwordStrength} else block 110");
                return 4 - passwordStrength;
            }

            Console.WriteLine(passwordStrength);
            return passwordStrength;

        }
    }
}
