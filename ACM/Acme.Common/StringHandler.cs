﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public class StringHandler
    {
        public string InsertSpaces(string source)
        {
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
    }
}
