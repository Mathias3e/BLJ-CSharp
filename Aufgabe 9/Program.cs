using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, wert, rest;
            string input, ter = "";

            do
            {
                ter = "";

                do
                {
                    Console.Write("Bitte geben Sie eine Zahl ein: ");
                    input = Console.ReadLine();
                } while (int.TryParse(input, out n) == false);

                do
                {
                    rest = n % 3;
                    ter = rest + ter;
                    wert = n / 3;
                    n = wert;
                } while (n != 0);

                Console.WriteLine("Die Ternärzahl lautet: " + ter);

                Console.Write("\nWollen sie die anwendung beenden (q): ");
                input = Console.ReadLine();
            } while (input != "q");
        }
    }
}
