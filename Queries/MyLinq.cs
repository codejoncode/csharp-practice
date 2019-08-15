using System;
using System.Collections.Generic;
using System.Text;

namespace Queries
{
    public static class MyLinq
    {
        //T is being added as a generic type paramater  this is also an extension method for IEnumerable<T> and returns an IEnumerable<T> 
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
           
            /*One implemnation of filter but not how LINQ does it. */
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item; //builds an IEnumerable.  or Ienumerable<T> or IEnumerator or IEnumerator<T> 
                    //builds a sequence of items that can be iterated over using a foreach loop. 
                }
            }

            
        }

        public static IEnumerable<double> Random()
        {
            //not an infinte loop if using .Take()
            var random = new Random();
            while(true)
            {
                yield return random.NextDouble();
            }
        }
    }
}
