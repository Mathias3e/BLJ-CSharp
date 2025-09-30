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
            int with = 50;
            int hight = with/2;

            int z = 1;
            int w = 2;
            int t = 250;

            string[,] forest = new string[hight, with];

            GeneratingForest(forest, with, hight);
            while (!Console.KeyAvailable)
            {
                Render(forest, with, hight);
                forest = (string[,])TreeGrow(forest, with, hight, w).Clone();
                forest = (string[,])FireExtinguish(forest, with, hight).Clone();
                forest = (string[,])FireSpread(forest, with, hight).Clone();
                forest = (string[,])CatchFire(forest, with, hight, z).Clone();
                Thread.Sleep(t);
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

                    if (probability <= 35)
                    {
                        forest[i, i2] = "B";
                    }
                    else if (probability > 35 && probability <= 50)
                    {
                        forest[i, i2] = "b";
                    }
                    else if (probability > 50 && probability <= 60)
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

        static string[,] CatchFire(string[,] forest, int with, int hight, int z)
        {
            Random random = new Random();
            int probability;
            string[,] forestClone = (string[,])forest.Clone();

            for (int i = 0; i < hight; i++)
            {
                for (int i2 = 0; i2 < with; i2++)
                {
                    probability = random.Next(1, with * hight + 1);

                    if (probability <= z && forest[i, i2] == "B")
                    {
                        forestClone[i, i2] = "F";
                    } 
                }
            }

            return forestClone;
        }

        static void Render(string[,] forest, int with, int hight)
        {
            Console.SetCursorPosition(0, 0);

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
                    else if (forest[i, i2] == "f")
                    {
                        Console.Write("\x1b[48;2;41;31;13m\u001b[38;2;81;41;41mf");
                    }
                    else if (forest[i, i2] == "b")
                    {
                        Console.Write("\x1b[48;2;41;31;13m\u001b[38;2;24;141;60mb");
                    }
                    else if (forest[i, i2] == "-f")
                    {
                        Console.Write("\x1b[48;2;41;31;13m ");
                    }
                }
                Console.Write("\n");
            }
        }

        static string[,] FireSpread(string[,] forest, int with, int hight)
        {
            string[,] forestClone = (string[,])forest.Clone();

            for (int i = 0; i < hight; i++)
            {
                for (int i2 = 0; i2 < with; i2++)
                {
                    if (i > 0 && i < (hight - 1) && i2 > 0 && i2 < (with - 1) && forest[i, i2] == "B" && ((forest[i + 1, i2 - 1] == "F" || forest[i + 1, i2 - 1] == "f") || forest[i + 1, i2] == "F" || forest[i + 1, i2 + 1] == "F" || forest[i, i2 - 1] == "F" || forest[i, i2 + 1] == "F" || forest[i - 1, i2 - 1] == "F" || forest[i - 1, i2] == "F" || forest[i - 1, i2 + 1] == "F")) // #
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == 0 && i2 > 0 && i2 < (with - 1) && forest[i, i2] == "B" && (forest[i, i2 - 1] == "F" || forest[i, i2 + 1] == "F" || forest[i + 1, i2 + 1] == "F" || forest[i + 1, i2] == "F" || (forest[i + 1, i2 - 1] == "F" || forest[i + 1, i2 - 1] == "f"))) // --
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == (hight - 1) && i2 > 0 && i2 < (with - 1) && forest[i, i2] == "B" && (forest[i - 1, i2 + 1] == "F" || forest[i - 1, i2] == "F" || forest[i - 1, i2 - 1] == "F" || forest[i, i2 + 1] == "F" || forest[i, i2 - 1] == "F")) // --
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i2 == 0 && i > 0 && i < (hight - 1) && forest[i, i2] == "B" && (forest[i + 1, i2 + 1] == "F" || forest[i + 1, i2] == "F" || forest[i, i2 + 1] == "F" || forest[i - 1, i2 + 1] == "F" || forest[i - 1, i2] == "F")) // |
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i2 == (with - 1) && i > 0 && i < (hight - 1) && forest[i, i2] == "B" && (forest[i + 1, i2] == "F" || (forest[i + 1, i2 - 1] == "F" || forest[i + 1, i2 - 1] == "f") || forest[i, i2 - 1] == "F" || forest[i - 1, i2 - 1] == "F" || forest[i - 1, i2] == "F")) // |
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == 0 && i2 == 0 && forest[i, i2] == "B" && (forest[i + 1, i2] == "F" || forest[i + 1, i2 + 1] == "F" || forest[i, i2 + 1] == "F")) //.
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == 0 && i2 == (with - 1) && forest[i, i2] == "B" && (forest[i + 1, i2] == "F" || (forest[i + 1, i2 - 1] == "F" || forest[i + 1, i2 - 1] == "f") || forest[i, i2 - 1] == "F")) //.
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == (hight - 1) && i2 == 0 && forest[i, i2] == "B" && (forest[i - 1, i2] == "F" || forest[i - 1, i2 + 1] == "F" || forest[i, i2 + 1] == "F")) //.
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == (hight - 1) && i2 == (with - 1) && forest[i, i2] == "B" && (forest[i - 1, i2 - 1] == "F" || forest[i - 1, i2] == "F" || forest[i, i2 - 1] == "F")) //.
                    {
                        forestClone[i, i2] = "F";
                    }
                }
            }

            return forestClone;
        }

        static string[,] FireExtinguish (string[,] forest, int with, int hight)
        {
            string[,] forestClone = (string[,])forest.Clone();

            for (int i = 0; i < hight; i++)
            {
                for (int i2 = 0; i2 < with; i2++)
                {
                    if (i > 0 && i < (hight - 1) && i2 > 0 && i2 < (with - 1) && forest[i, i2] == "F" && (forest[i + 1, i2 - 1] != "B" && forest[i + 1, i2] != "B" && forest[i + 1, i2 + 1] != "B" && forest[i, i2 - 1] != "B" && forest[i, i2 + 1] != "B" && forest[i - 1, i2 - 1] != "B" && forest[i - 1, i2] != "B" && forest[i - 1, i2 + 1] != "B")) // #
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == 0 && i2 > 0 && i2 < (with - 1) && forest[i, i2] == "F" && (forest[i, i2 - 1] != "B" && forest[i, i2 + 1] != "B" && forest[i + 1, i2 + 1] != "B" && forest[i + 1, i2] != "B" && forest[i + 1, i2 - 1] != "B")) // --
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == (hight - 1) && i2 > 0 && i2 < (with - 1) && forest[i, i2] == "F" && (forest[i - 1, i2 + 1] != "B" && forest[i - 1, i2] != "B" && forest[i - 1, i2 - 1] != "B" && forest[i, i2 + 1] != "B" && forest[i, i2 - 1] != "B")) // --
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i2 == 0 && i > 0 && i < (hight - 1) && forest[i, i2] == "F" && (forest[i + 1, i2 + 1] != "B" && forest[i + 1, i2] != "B" && forest[i, i2 + 1] != "B" && forest[i - 1, i2 + 1] != "B" && forest[i - 1, i2] != "B")) // |
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i2 == (with - 1) && i > 0 && i < (hight - 1) && forest[i, i2] == "F" && (forest[i + 1, i2] != "B" && forest[i + 1, i2 - 1] != "B" && forest[i, i2 - 1] != "B" && forest[i - 1, i2 - 1] != "B" && forest[i - 1, i2] != "B")) // |
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == 0 && i2 == 0 && forest[i, i2] == "F" && (forest[i + 1, i2] != "B" && forest[i + 1, i2 + 1] != "B" && forest[i, i2 + 1] != "B")) //.
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == 0 && i2 == (with - 1) && forest[i, i2] == "F" && (forest[i + 1, i2] != "B" && forest[i + 1, i2 - 1] != "B" && forest[i, i2 - 1] != "B")) //.
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == (hight - 1) && i2 == 0 && forest[i, i2] == "F" && (forest[i - 1, i2] != "B" && forest[i - 1, i2 + 1] != "B" && forest[i, i2 + 1] != "B")) //.
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == (hight - 1) && i2 == (with - 1) && forest[i, i2] == "F" && (forest[i - 1, i2 - 1] != "B" && forest[i - 1, i2] != "B" && forest[i, i2 - 1] != "B")) //.
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (forest[i, i2] == "f")
                    {
                        forestClone[i, i2] = "-f";
                    }
                }
            }

            return forestClone;
        }

        static string[,] TreeGrow(string[,] forest, int with, int hight, int w)
        {
            string[,] forestClone = (string[,])forest.Clone();
            Random random = new Random();
            int probability;

            for (int i = 0; i < hight; i++)
            {
                for (int i2 = 0; i2 < with; i2++)
                {
                    if (forestClone[i,i2] == "-f")
                    {
                        probability = random.Next(1, 101);
                        if (probability < w)
                        {
                            forestClone[i, i2] = "b";
                        }
                    } else if (forestClone[i, i2] == "b") {
                        probability = random.Next(1, 101);
                        if (probability < 50)
                        {
                            forestClone[i, i2] = "B";
                        }
                    }
                }
            }

            return forestClone;
        }
    }
}