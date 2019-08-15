using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileList
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Jonathan";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("*************");
            ShowLargeFilesWithLinq(path);

        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            //var query = from file in new DirectoryInfo(path).GetFiles()
            //            orderby file.Length descending
            //            select file;
            //foreach (var file in query.Take(5))
            //{
            //    Console.WriteLine($"{file.Name,-20}:{file.Length,10:N0}");
            //}


            //This here is the same as the above just different. 
            var query = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length)
                        .Take(5);
                        
            foreach (var file in query)
            {
                Console.WriteLine($"{file.Name,-20}:{file.Length,10:n0}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            //foreach (FileInfo file in files)
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                //string format  the name left jusify inside of 20 spaces   right justify the lenght format as a number  with commas and zero spaces after the decimal point.
                Console.WriteLine($"{file.Name, -20}:{file.Length, 10:N0}");
            }
        }
    }
    // This class does not inherit from another class but does  take on the Interface from IComparer. 
    /// <summary>
    /// This will use the IComparer interface and be used as a sorting helper for Array.Sort.  This is the 
    /// old way you had to do things before you could use LINQ. 
    /// </summary>
    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
