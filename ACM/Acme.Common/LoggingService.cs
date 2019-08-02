using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class LoggingService
    {
        /// <summary>
        /// Write to file will take a List of Objects. use Object type when you do not know the type of each item. 
        /// </summary>
        /// <param name="itemsToLog"></param>
        public static void WriteToFile(List<ILoggable> itemsToLog)
        {
            foreach (var item in itemsToLog)
            {
                //inheritance based polymorphism 
                Console.WriteLine(item.Log());
            }
        }
    }
}
