using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int zahl;

            //-------------------------------------------------------------------------------

            Console.Write("Bitte geben Sie eine Zahl ein: ");
            input = Console.ReadLine();

            while (int.TryParse(input, out zahl) == false)
            {
                Console.WriteLine("Eingabefehler. Bitte geben Sie eine Zahl ein: ");
                input = Console.ReadLine();
            }

            Console.WriteLine($"Deine Zahl ist {zahl}");

            //oder

            do {
                Console.WriteLine("Bitte geben Sie eine Zahl ein: ");
                input = Console.ReadLine();
            } while (int.TryParse(input, out zahl) == false);

            Console.WriteLine($"Deine Zahl ist {zahl}");

            //adwanced

            while (!int.TryParse(input, out zahl) || zahl > 31 || zahl < 28)
            {
                if (!int.TryParse(input, out zahl))
                {
                    Console.WriteLine("Ungültige Eingabe. Ganzzahl erwartet.");
                }
                else if (zahl < 28 || zahl > 31)
                {
                    Console.WriteLine($"Ungültige Eingabe. Ein Monat mit {zahl} Tagen gibt's nicht.");
                }

                input = Console.ReadLine();
            }

            //-------------------------------------------------------------------------------

            Console.ReadKey();
        }
    }
}
