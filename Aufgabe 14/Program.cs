using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int jahr;

            Console.WriteLine("Prüfen, ob es sich bei einem Jahr um ein Schaltjahr handelt.\n************************************************************");
            do
            {
                do
                {
                    Console.Write("\nEingabe Jahr (q to quit): ");
                    input = Console.ReadLine();
                } while (int.TryParse(input, out jahr) == false && input != "q");

                Console.Write("\n");

                if ((jahr % 4 == 0 && jahr % 100 != 0) || (jahr % 400 == 0 && jahr % 4000 != 0))
                {
                    Console.Write($"Das Jahr {jahr} ist ein Schaltjahr.");
                }
                else
                {
                    Console.Write($"Das Jahr {jahr} ist KEIN Schaltjahr.");
                }

                Console.Write("\n");
            } while (input != "q");
        }
    }
}
