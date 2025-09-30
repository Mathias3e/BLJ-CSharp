using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kür_Waldbrand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int with = 60;
            int hight = 30;

            int z = 1;
            int w = 500;

            string[,] forest = new string[hight, with];

            GeneratingForest(forest, with, hight);
            while (!Console.KeyAvailable)
            {
                Render(forest, with, hight);
                Thread.Sleep(w);
                CatchFire(forest, with, hight, z);
            }
        }

        static void GeneratingForest(string[,] forest, int with, int hight)
        {
            Random random = new Random();
            int probability;

            for (int i = 0; i < hight; i++)
            {
                for (int i2 = 0; i2 < with; i2++)
                {
                    probability = random.Next(1, 101);

                    if (probability <= 45)
                    {
                        forest[i, i2] = "B";
                    }
                    else if (probability > 45 && probability <= 60)
                    {
                        forest[i, i2] = "S";
                    }
                    else if (probability > 60 && probability <= 100)
                    {
                        forest[i, i2] = "-";
                    }
                }
            }
        }

        static void CatchFire(string[,] forest, int with, int hight, int z)
        {
            Random random = new Random();
            int probability;

            for (int i = 0; i < hight; i++)
            {
                for (int i2 = 0; i2 < with; i2++)
                {
                    probability = random.Next(1, with * hight + 1);

                    if (probability <= z && forest[i, i2] == "B")
                    {
                        forest[i, i2] = "F";
                    } 
                }
            }
        }

        static void Render(string[,] forest, int with, int hight)
        {
           Console.Clear();

            for (int i = 0; i < hight; i++)
            {
                for (int i2 = 0; i2 < with; i2++)
                {
                    if (forest[i, i2] == "B")
                    {
                        Console.Write("\x1b[48;2;41;31;13m\u001b[38;2;15;83;36mB");
                    }
                    else if (forest[i, i2] == "S")
                    {
                        Console.Write("\x1b[48;2;41;31;13m\u001b[38;2;135;135;135mS");
                    }
                    else if (forest[i, i2] == "-")
                    {
                        Console.Write("\x1b[48;2;41;31;13m ");
                    }
                    else if (forest[i, i2] == "F")
                    {
                        Console.Write("\x1b[48;2;41;31;13m\u001b[38;2;227;34;34mF");
                    }                    
                }
                Console.Write("\n");
            }
        }
    }
}
