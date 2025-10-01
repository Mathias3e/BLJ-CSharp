using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            DateTime today = DateTime.Today;
            DateTime birthday;
            TimeSpan age;

            Console.Write("Bitte gib ein Geburtsdatum ein: ");
            input = Console.ReadLine();

            while (DateTime.TryParse(input, out birthday) == false)
            {
                Console.Write("Bitte gib ein gültiges Datum ein: ");
                input = Console.ReadLine();
            }

            age = today - birthday;

            Console.WriteLine($"\nJahren: {age.Days / 365.25}");
            Console.WriteLine($"Monaten: {age.Days / 30.44}");
            Console.WriteLine($"Wochen: {age.Days / 7.0}");
            Console.WriteLine($"Tagen: {age.Days}");

            Console.ReadKey();
        }
    }
}
