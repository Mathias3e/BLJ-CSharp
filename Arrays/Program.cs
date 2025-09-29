using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] monate = new string[12] { "Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };
            int[,] a = new int[,] { { 1, 4, 2 }, { 3, 6, 8 } };
            int?[][] k = new int?[][] { new int?[] { null, 3 }, new int?[] { 2, 4, 6, 8 }, new int?[] { 11 }, new int?[] { 20, 30, 40 } };

            Console.WriteLine(monate[4]);
            Console.WriteLine(a[0, 1]);
            Console.WriteLine(k[0][0]);

            Console.ReadKey();
        }
    }
}
