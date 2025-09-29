using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufagbe_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int withTrunk, heightTrunk, heightTip;

            do
            {
                Console.Write("Breite des Stammes? ");
                input = Console.ReadLine();
            } while (int.TryParse(input, out withTrunk) == false);

            do
            {
                Console.Write("Höhe des Stammes? ");
                input = Console.ReadLine();
            } while (int.TryParse(input, out heightTrunk) == false);

            do
            {
                Console.Write("Höhe der Krone? ");
                input = Console.ReadLine();
            } while (int.TryParse(input, out heightTip) == false);

            drawTree(withTrunk, heightTrunk, heightTip);

            Console.ReadKey();
        }

        static void drawTree(int wTr, int hTr, int hTi)
        {
            Console.Write("\n");

            for (int i = 1; i <= hTi+hTr; i++)
            {
                if (i <= hTi)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    for (int i2 = 0; i2 < (hTi - 0.5) * 2; i2++)
                    {
                        if (i2 >= hTi - 0.5 - i && i2 <= hTi + 0.5 + i) //Weiter macvhen
                        {
                            Console.Write("*");
                        } else
                        {
                            Console.Write(" ");
                        }
                    }
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    for (int i2 = 0; i2 < hTr; i2++)
                    {
                        Console.Write("*");
                    }
                }
                
                Console.Write("\n");
            }
        }
    }
}
