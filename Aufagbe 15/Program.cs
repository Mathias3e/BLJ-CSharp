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
                    for (int i2 = 1; i2 <= (hTi - 0.5) * 2; i2++)
                    {
                        if (i2 >= hTi + 1 - i && i2 <= hTi - 1 + i)
                        {
                            Console.Write("\x1b[38;2;185;213;75m*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    for (int i2 = 1; i2 <= (hTi - 0.5) * 2; i2++)
                    {
                        if (i2 > (((hTi - 0.5) * 2) - wTr) / 2 && i2 <= (((hTi - 0.5) * 2) - wTr) / 2 + wTr)
                        {
                            Console.Write("\x1b[38;2;102;44;23m*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                
                Console.Write("\n");
            }
        }
    }
}
