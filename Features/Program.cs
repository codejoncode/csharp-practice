using System;
using System.Collections.Generic;
using System.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            //returns an integer and takes a int 
            Func<int, int> square = x => x*x;

            Console.WriteLine(square(2));
            //Func is a delegate. 
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(add(4,15));
            
            //always returns void Action type. 
            Action<int> write = x => Console.WriteLine(x);
            write(square(add(3,5)));

            //Employee[] developers = new Employee[]
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Scott"},
                new Employee { Id = 2, Name = "Chris"},
            };

            //List<Employee> sales = new List<Employee>()
            IEnumerable < Employee > sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Alex"}
            };

            Console.WriteLine(developers.Count());
            Console.WriteLine(sales.Count());
            //IEnumerable<T>   and provides methods. 
            //IEnumerator<Employee> enumerator = developers.GetEnumerator();
            IEnumerator<Employee> enumerator = sales.GetEnumerator();
            //a foreach statement the hard way. 
            //while(enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}
            // name method  
            foreach (var employee in developers.Where(NameStartsWithS))
            {
                Console.WriteLine(employee.Name);
            }

            //Anonymous method 
            foreach ( var employee in developers.Where(
                delegate (Employee employee)
                {
                    return employee.Name.StartsWith("S");
                }
                ))
            {
                Console.WriteLine(employee.Name);
            }

            //Lambda expression 
            foreach (var employee in developers.Where(employee => employee.Name.StartsWith("S")))
            {
                Console.WriteLine(employee.Name);
            }

            //only want employees name whose length is 5 characters and in order 
            foreach (var employee in developers.Where(e => e.Name.Length == 5).OrderBy(e => e.Name))
            {
                Console.WriteLine(employee.Name);
            }

            //method syntax 
            var query = developers.Where(e => e.Name.Length == 5).OrderBy(e => e.Name);
            //You can use .Select(e => e);  but its option on method syntax 
            //Add .Count() to the method   chained at the end 

            //query syntax
            var query2 = from developer in developers
                         where developer.Name.Length == 5
                         orderby developer.Name
                         select developer;
            //would have to query2.Count()  to get the count no chanining. 
            foreach (var employee in query2)
            {
                Console.WriteLine(employee.Name);
            }
        }

        //private static int Square(int arg)
        //{
        //    throw new NotImplementedException();
        //}

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S");
        }
    }
}
