using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufagbe_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int Number1;
            int Number2;

            do
            {
                Console.Write("Zahl 1: ");
                input = Console.ReadLine();
            } while (int.TryParse(input, out Number1) == false);

            do
            {
                Console.Write("Zahl 2: ");
                input = Console.ReadLine();
            } while (int.TryParse(input, out Number2) == false || Number2-Number1 <= 0);

            Console.Write("\n");

            Console.WriteLine($"-------------------------------------\n| {"Zahl".PadRight(2)} | {"Quersumme".PadRight(2)} | Zahl / Quersumme\n-------------------------------------");
            for (int i = 0; i <= Number2 - Number1; i++)
            {
                if ((Number1 + i) % BerechneQuersumme(Number1 + i) == 0)
                {
                    Console.WriteLine($"| {(Number1 + i).ToString().PadRight(4)} | {BerechneQuersumme(Number1 + i).ToString().PadRight(9)} | {(Number1 + i) / (double)BerechneQuersumme(Number1+i)}");
                }
            }
            Console.ReadKey();
        }
        static int BerechneQuersumme(int zahl)
        {
            int sum = 0;

            while (zahl != 0)
            {
                sum = sum + (zahl % 10);
                zahl /= 10;
            }

            return sum;
        }
    }
}
