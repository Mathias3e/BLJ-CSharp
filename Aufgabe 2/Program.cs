using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte days;
            uint seconds;
            string input;


            Console.WriteLine("Berechnung von Sekunden eines Monats in Abhängigkeit seiner Anzahl Tage");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Wieviele Tage hat der Monat, für den Sie die Sekundenzahl berechnen wollen?");
            input = Console.ReadLine();

            while (!byte.TryParse(input, out days) || days > 31 || days < 28)
            {
                if (!byte.TryParse(input, out days))
                {
                    Console.WriteLine("Ungültige Eingabe. Ganzzahl erwartet.");
                }
                else if (days < 28 || days > 31)
                {
                    Console.WriteLine($"Ungültige Eingabe. Ein Monat mit {days} Tagen gibt's nicht.");
                }

                input = Console.ReadLine();
            }

            seconds = (uint)days * 24 * 60 * 60;

            Console.WriteLine($"Ein Monat mit {days} Tagen hat {seconds} Sekunden.");
        }
    }
}
