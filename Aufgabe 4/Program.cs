using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] months = {"Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember"};
            byte month;
            string input;

            Console.Write("Zahl eingeben: ");
            input = Console.ReadLine();

            while (!byte.TryParse(input, out month) || month < 1 || month > 12)
            {
                if (!byte.TryParse(input, out month))
                {
                    Console.WriteLine("Ungültige Eingabe. Ganzzahl erwartet.");
                }
                else if (month < 1 || month > 12)
                {
                    Console.WriteLine($"Ungültige Eingabe. Einen {month} Monat gibt's nicht.");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Monat: {months[month-1]}");

            Console.ReadKey();
        }
    }
}
