using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aufgabe_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint km;
            uint runden;
            string redy;

            Console.WriteLine("Wie viele Kilometer möchtest du rennen?");
            km = Convert.ToUInt32(Console.ReadLine());

            if (km > 42)
            {
                Console.WriteLine("Das schaffst du nicht!");
            } else
            {
                runden = km * 1000 / 400;
                Console.WriteLine($"Das sind {runden} Runden. Bereit für den Lauf (Y/N)?");
                redy = Console.ReadLine();

                if (redy == "Y")
                {
                    int i = 1;
                    while (i <= runden)
                    {
                        Console.WriteLine($"Du laufst Runde {i}");
                        Thread.Sleep(1000);
                        i++;
                    }
                    Console.WriteLine("Du hast es geschafft!");
                    Console.ReadKey();
                } else
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
