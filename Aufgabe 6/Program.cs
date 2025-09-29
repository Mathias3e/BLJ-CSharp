using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------\nKleines 1x1\n-----------\n");

            for (int i = 1; i <= 10; i++)
            {
                for (int i2 = 1; i2 <= 10; i2++)
                {
                    Console.Write($"{i2 * i}\t");
                }
                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }
}
