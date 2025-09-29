using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufagbe_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double zahl1;
            double zahl2;
            string input;

            Console.WriteLine("Dieses Programm berechnet die Summe von zwei Zahlen.\n");

            do
            {
                Console.Write("Zahl 1: ");
                input = Console.ReadLine();
            } while (double.TryParse(input, out zahl1) == false);

            do
            {
                Console.Write("Zahl 2: ");
                input = Console.ReadLine();
            } while (double.TryParse(input, out zahl2) == false);

            Console.Write($"Summe: {zahl1 + zahl2}");

            Console.ReadKey();
        }
    }
}
