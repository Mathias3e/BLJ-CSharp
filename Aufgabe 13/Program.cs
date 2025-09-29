using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int number;

            do
            {
                Console.Write("Wie lang soll die Linie sein?\nDeine Eingabe: ");
                input = Console.ReadLine();
            } while (int.TryParse(input, out number) == false);

            Console.Write("\n");

            for (int i = 1; i <= number; i++)
            {
                for (int i2 = 1; i2 <= number; i2++)
                {
                    if (i2 == i)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
