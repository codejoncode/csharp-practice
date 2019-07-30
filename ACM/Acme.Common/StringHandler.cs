using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    
    public static class StringHandler
    {
        //  this keyword  extends the method
        /// <summary>
        /// Inserts spaces before each capital letter in a string 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string InsertSpaces( this string source)
        {
            if (IsAllUpper(source))
            {
                // if it is all uppper case return the string as is. 
                Console.WriteLine("Testing if this line gets triggered");
                return source; 
            }
            string result = string.Empty;

            if(!String.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    //finds a uppercase letter then inserts a space
                    if (char.IsUpper(letter))
                    {
                        //Trim any spaces already there 
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter; 
                }
            }
            result = result.Trim();
            return result; 
        }
        static bool IsAllUpper(string input)        
        {
            input = input.Replace(" ", "");
            for (int i = 0; i< input.Length; i++)
            {
                if (!Char.IsUpper(input[i]))
                    return false; 
            }
            return true; 
        }
    }
}
