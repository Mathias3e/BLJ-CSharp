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
            int width;   // Optimal 50
            int height;  // Optimal 25

            int z;      // Optimal 1
            int w;      // Optimal 2
            int t;      // Optimal 250

            int playerx = 0;
            int playery = 0;

            string input;

            do
            {
                Console.Write("Zu wie viel Prozent soll ein Baum anfangen zu brennen (Optimal ca. 1): ");
                input = Console.ReadLine();
                if (input == "")
                {
                    input = $"{12}";
                }
            } while (!int.TryParse(input, out z));
            Console.Write("\n");
            do
            {
                Console.Write("Zu wie viel Prozent soll ein Baum anfangen zu wachsen (Optimal ca. 2): ");
                input = Console.ReadLine();
                if (input == "")
                {
                    input = $"{2}";
                }
            } while (!int.TryParse(input, out w));
            Console.Write("\n");
            do
            {
                Console.Write("Wie viele Millisekunden soll pro Frame gewartet werden (Optimal 24 - 500): ");
                input = Console.ReadLine();
                if (input == "")
                {
                    input = $"{24}";
                }
            } while (!int.TryParse(input, out t));
            Console.Write("\n");
            do
            {
                Console.Write("Wie hoch soll der Wald sein (Optimal 5 - 25): ");
                input = Console.ReadLine();
                if (input == "")
                {
                    input = $"{25}";
                }
            } while (!int.TryParse(input, out height));
            Console.Write("\n");
            do
            {
                Console.Write($"Wie breit soll der Wald sein (Optimal {height * 2}): ");
                input = Console.ReadLine();
                if (input == "")
                {
                    input = $"{height * 2}";
                }
            } while (!int.TryParse(input, out width));

            Console.Clear();

            string[,] forest = new string[height, width];

            GeneratingForest(forest, width, height);

            while (true)
            {
                Render(forest, width, height, playerx, playery);
                (playerx, playery) = PlayerMovment(width, height, playerx, playery);
                if (Exit() == true) { break; }
                (playerx, playery) = PlayerMovment(width, height, playerx, playery);
                forest = (string[,])TreeGrow(forest, width, height, w).Clone();
                (playerx, playery) = PlayerMovment(width, height, playerx, playery);
                forest = (string[,])FireExtinguish(forest, width, height).Clone();
                (playerx, playery) = PlayerMovment(width, height, playerx, playery);
                forest = (string[,])FireSpread(forest, width, height).Clone();
                (playerx, playery) = PlayerMovment(width, height, playerx, playery);
                forest = (string[,])CatchFire(forest, width, height, playerx, playery).Clone();
                (playerx, playery) = PlayerMovment(width, height, playerx, playery);
                Thread.Sleep(Math.Max(1, t));
            }
        }

        static bool Exit()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Q)
                {
                    return true;
                }
            }
            return false;
        }

        static void GeneratingForest(string[,] forest, int width, int height)
        {
            Random random = new Random();
            int probability;

            for (int i = 0; i < height; i++)
            {
                for (int i2 = 0; i2 < width; i2++)
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

        static (int, int) PlayerMovment(int width, int height, int playerx, int playery)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    playery--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    playery++;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    playerx--;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    playerx++;
                }
            }
            return (playerx, playery);
        }

        static string[,] CatchFire(string[,] forest, int width, int height, int playerx, int playery)
        {
            string[,] forestClone = (string[,])forest.Clone();

            if (Console.KeyAvailable && forestClone[playery, playerx] == "B")
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Spacebar)
                {
                    forestClone[playery, playerx] = "F";
                }
            }
            return forestClone;
        }

        static void Render(string[,] forest, int width, int height, int playerx, int playery)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < height; i++)
            {
                for (int i2 = 0; i2 < width; i2++)
                {
                    if (playerx == i2 && playery == i)
                    {
                        if (forest[i, i2] == "B")
                        {
                            Console.Write("\x1b[48;2;84;63;26m\x1b[38;2;15;83;36mB");
                        }
                        else if (forest[i, i2] == "S")
                        {
                            Console.Write("\x1b[48;2;84;63;26m\x1b[38;2;135;135;135mS");
                        }
                        else if (forest[i, i2] == "-")
                        {
                            Console.Write("\x1b[48;2;84;63;26m ");
                        }
                        else if (forest[i, i2] == "F")
                        {
                            Console.Write("\x1b[48;2;84;63;26m\x1b[38;2;227;34;34mF");
                        }
                        else if (forest[i, i2] == "f")
                        {
                            Console.Write("\x1b[48;2;84;63;26m\x1b[38;2;81;41;41mf");
                        }
                        else if (forest[i, i2] == "b")
                        {
                            Console.Write("\x1b[48;2;84;63;26m\x1b[38;2;24;141;60mb");
                        }
                        else if (forest[i, i2] == "-f")
                        {
                            Console.Write("\x1b[48;2;84;63;26m ");
                        }
                    }
                    else
                    {
                        if (forest[i, i2] == "B")
                        {
                            Console.Write("\x1b[48;2;41;31;13m\x1b[38;2;15;83;36mB");
                        }
                        else if (forest[i, i2] == "S")
                        {
                            Console.Write("\x1b[48;2;41;31;13m\x1b[38;2;135;135;135mS");
                        }
                        else if (forest[i, i2] == "-")
                        {
                            Console.Write("\x1b[48;2;41;31;13m ");
                        }
                        else if (forest[i, i2] == "F")
                        {
                            Console.Write("\x1b[48;2;41;31;13m\x1b[38;2;227;34;34mF");
                        }
                        else if (forest[i, i2] == "f")
                        {
                            Console.Write("\x1b[48;2;41;31;13m\x1b[38;2;81;41;41mf");
                        }
                        else if (forest[i, i2] == "b")
                        {
                            Console.Write("\x1b[48;2;41;31;13m\x1b[38;2;24;141;60mb");
                        }
                        else if (forest[i, i2] == "-f")
                        {
                            Console.Write("\x1b[48;2;41;31;13m ");
                        }
                    }
                }
                Console.Write("\n");
            }

            Console.Write("\n\x1b[0mDrücke \"q\", um zu beenden.");
        }

        static string[,] FireSpread(string[,] forest, int width, int height)
        {
            string[,] forestClone = (string[,])forest.Clone();

            for (int i = 0; i < height; i++)
            {
                for (int i2 = 0; i2 < width; i2++)
                {
                    if (i > 0 && i < (height - 1) && i2 > 0 && i2 < (width - 1) && forest[i, i2] == "B" && (forest[i + 1, i2 - 1] == "F" || forest[i + 1, i2] == "F" || forest[i + 1, i2 + 1] == "F" || forest[i, i2 - 1] == "F" || forest[i, i2 + 1] == "F" || forest[i - 1, i2 - 1] == "F" || forest[i - 1, i2] == "F" || forest[i - 1, i2 + 1] == "F")) // #
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == 0 && i2 > 0 && i2 < (width - 1) && forest[i, i2] == "B" && (forest[i, i2 - 1] == "F" || forest[i, i2 + 1] == "F" || forest[i + 1, i2 + 1] == "F" || forest[i + 1, i2] == "F" || forest[i + 1, i2 - 1] == "F")) // --
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == (height - 1) && i2 > 0 && i2 < (width - 1) && forest[i, i2] == "B" && (forest[i - 1, i2 + 1] == "F" || forest[i - 1, i2] == "F" || forest[i - 1, i2 - 1] == "F" || forest[i, i2 + 1] == "F" || forest[i, i2 - 1] == "F")) // --
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i2 == 0 && i > 0 && i < (height - 1) && forest[i, i2] == "B" && (forest[i + 1, i2 + 1] == "F" || forest[i + 1, i2] == "F" || forest[i, i2 + 1] == "F" || forest[i - 1, i2 + 1] == "F" || forest[i - 1, i2] == "F")) // |
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i2 == (width - 1) && i > 0 && i < (height - 1) && forest[i, i2] == "B" && (forest[i + 1, i2] == "F" || forest[i + 1, i2 - 1] == "F" || forest[i, i2 - 1] == "F" || forest[i - 1, i2 - 1] == "F" || forest[i - 1, i2] == "F")) // |
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == 0 && i2 == 0 && forest[i, i2] == "B" && (forest[i + 1, i2] == "F" || forest[i + 1, i2 + 1] == "F" || forest[i, i2 + 1] == "F")) //.
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == 0 && i2 == (width - 1) && forest[i, i2] == "B" && (forest[i + 1, i2] == "F" || forest[i + 1, i2 - 1] == "F" || forest[i, i2 - 1] == "F")) //.
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == (height - 1) && i2 == 0 && forest[i, i2] == "B" && (forest[i - 1, i2] == "F" || forest[i - 1, i2 + 1] == "F" || forest[i, i2 + 1] == "F")) //.
                    {
                        forestClone[i, i2] = "F";
                    }
                    else if (i == (height - 1) && i2 == (width - 1) && forest[i, i2] == "B" && (forest[i - 1, i2 - 1] == "F" || forest[i - 1, i2] == "F" || forest[i, i2 - 1] == "F")) //.
                    {
                        forestClone[i, i2] = "F";
                    }
                }
            }

            return forestClone;
        }

        static string[,] FireExtinguish(string[,] forest, int width, int height)
        {
            string[,] forestClone = (string[,])forest.Clone();

            for (int i = 0; i < height; i++)
            {
                for (int i2 = 0; i2 < width; i2++)
                {
                    if (i > 0 && i < (height - 1) && i2 > 0 && i2 < (width - 1) && forest[i, i2] == "F" && (forest[i + 1, i2 - 1] != "B" && forest[i + 1, i2] != "B" && forest[i + 1, i2 + 1] != "B" && forest[i, i2 - 1] != "B" && forest[i, i2 + 1] != "B" && forest[i - 1, i2 - 1] != "B" && forest[i - 1, i2] != "B" && forest[i - 1, i2 + 1] != "B")) // #
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == 0 && i2 > 0 && i2 < (width - 1) && forest[i, i2] == "F" && (forest[i, i2 - 1] != "B" && forest[i, i2 + 1] != "B" && forest[i + 1, i2 + 1] != "B" && forest[i + 1, i2] != "B" && forest[i + 1, i2 - 1] != "B")) // --
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == (height - 1) && i2 > 0 && i2 < (width - 1) && forest[i, i2] == "F" && (forest[i - 1, i2 + 1] != "B" && forest[i - 1, i2] != "B" && forest[i - 1, i2 - 1] != "B" && forest[i, i2 + 1] != "B" && forest[i, i2 - 1] != "B")) // --
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i2 == 0 && i > 0 && i < (height - 1) && forest[i, i2] == "F" && (forest[i + 1, i2 + 1] != "B" && forest[i + 1, i2] != "B" && forest[i, i2 + 1] != "B" && forest[i - 1, i2 + 1] != "B" && forest[i - 1, i2] != "B")) // |
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i2 == (width - 1) && i > 0 && i < (height - 1) && forest[i, i2] == "F" && (forest[i + 1, i2] != "B" && forest[i + 1, i2 - 1] != "B" && forest[i, i2 - 1] != "B" && forest[i - 1, i2 - 1] != "B" && forest[i - 1, i2] != "B")) // |
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == 0 && i2 == 0 && forest[i, i2] == "F" && (forest[i + 1, i2] != "B" && forest[i + 1, i2 + 1] != "B" && forest[i, i2 + 1] != "B")) //.
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == 0 && i2 == (width - 1) && forest[i, i2] == "F" && (forest[i + 1, i2] != "B" && forest[i + 1, i2 - 1] != "B" && forest[i, i2 - 1] != "B")) //.
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == (height - 1) && i2 == 0 && forest[i, i2] == "F" && (forest[i - 1, i2] != "B" && forest[i - 1, i2 + 1] != "B" && forest[i, i2 + 1] != "B")) //.
                    {
                        forestClone[i, i2] = "f";
                    }
                    else if (i == (height - 1) && i2 == (width - 1) && forest[i, i2] == "F" && (forest[i - 1, i2 - 1] != "B" && forest[i - 1, i2] != "B" && forest[i, i2 - 1] != "B")) //.
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

        static string[,] TreeGrow(string[,] forest, int width, int height, int w)
        {
            string[,] forestClone = (string[,])forest.Clone();
            Random random = new Random();
            int probability;

            for (int i = 0; i < height; i++)
            {
                for (int i2 = 0; i2 < width; i2++)
                {
                    if (forestClone[i, i2] == "-f")
                    {
                        probability = random.Next(1, 101);
                        if (probability < w)
                        {
                            forestClone[i, i2] = "b";
                        }
                    }
                    else if (forestClone[i, i2] == "b")
                    {
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