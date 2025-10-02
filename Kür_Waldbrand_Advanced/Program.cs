using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
            int s;      // Optimal 30

            int playerx = 0;
            int playery = 0;

            int seed;

            string input;

            bool game = true;

            //Thank you for playing my Game

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
                Console.Write("Wie vile Felder sollen mit Wasser/See bedeckt sein (Optimal 30): ");
                input = Console.ReadLine();
                if (input == "")
                {
                    input = $"{30}";
                }
            } while (!int.TryParse(input, out s));
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
            Console.Write("\n");
            do
            {
                Console.Write($"Was soll der Seed sein: ");
                input = Console.ReadLine();
                if (input == "")
                {
                    Random random = new Random();
                    input = random.Next(1, int.MaxValue).ToString();
                } else
                {
                    input = Math.Abs(input.GetHashCode()).ToString();
                }
            } while (!int.TryParse(input, out seed));

            Console.Clear();

            string[,] forest = new string[height, width];

            GeneratingForest(forest, width, height, seed);

            forest = (string[,])AddFirstWater(forest, width, height, seed).Clone();
            forest = (string[,])AddWater(forest, width, height, s, seed).Clone();

            while (game)
            {
                Render(forest, width, height, playerx, playery, seed);
                (playerx, playery, game) = KeysPres(width, height, playerx, playery, seed);
                forest = (string[,])TreeGrow(forest, width, height, w, seed).Clone();
                forest = (string[,])FireExtinguish(forest, width, height).Clone();
                forest = (string[,])FireSpread(forest, width, height).Clone();
                forest = (string[,])CatchFire(forest, width, height, playerx, playery).Clone();
                Thread.Sleep(Math.Max(1, t));
            }
        }
        static void GeneratingForest(string[,] forest, int width, int height, int seed)
        {
            Random random = new Random(seed);
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

        static string[,] AddFirstWater(string[,] forest, int width, int height, int seed)
        {
            string[,] forestClone = (string[,])forest.Clone();

            Random random = new Random(seed);
            int positionx = random.Next(1, width - 1);
            int positiony = random.Next(1, height - 1);

            forestClone[positiony, positionx] = "W";

            return forestClone;
        }

        static string[,] AddWater(string[,] forest, int width, int height, int s, int seed)
        {
            string[,] forestClone = (string[,])forest.Clone();

            Random random = new Random(seed);
            int probability;
            int water = 1;
            bool addWater = false;

            while (forestClone.Cast<string>().Count(x => x == "W") < s)
            {
                for (int i = 1; i < height - 1 && !addWater; i++)
                {
                    for (int i2 = 1; i2 < width - 1; i2++)
                    {
                        probability = random.Next(1, 101);

                        if ((forestClone[i, i2 - 1] == "W" || forestClone[i, i2 + 1] == "W") && probability < 50)
                        {
                            forestClone[i, i2] = "W";
                            water++;
                            addWater = true;
                        }
                        else if ((forestClone[i - 1, i2] == "W" || forestClone[i + 1, i2] == "W") && probability < 25)
                        {
                            forestClone[i, i2] = "W";
                            water++;
                            addWater = true;
                        }
                    }
                }
                addWater = false;
            }

            return forestClone;
        }

        static (int, int, bool) KeysPres(int width, int height, int playerx, int playery, int seed)
        {
            bool game = true;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Q)
                {
                    game = false;
                }

                if (key.Key == ConsoleKey.C)
                {
                    //System.Windows.Forms.Clipboard.SetText(seed);
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    playery = Math.Max(0, playery - 1);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    playery = Math.Min(height - 1, playery + 1);
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    playerx = Math.Max(0, playerx - 1);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    playerx = Math.Min(width - 1, playerx + 1);
                }
            }
            return (playerx, playery, game);
        }

        static string[,] CatchFire(string[,] forest, int width, int height, int playerx, int playery)
        {
            string[,] forestClone = (string[,])forest.Clone();

            if (forestClone[playery, playerx] == "B")
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.F)
                    {
                        forestClone[playery, playerx] = "F";
                    }
                }
            }
            return forestClone;
        }

        static void Render(string[,] forest, int width, int height, int playerx, int playery, int seed)
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
                        else if (forest[i, i2] == "W")
                        {
                            Console.Write("\x1b[48;2;38;124;182m ");
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
                        else if (forest[i, i2] == "W")
                        {
                            Console.Write("\x1b[48;2;38;124;182m ");
                        }
                    }
                }
                Console.Write("\n");
            }

            Console.Write($"\n\x1b[0mDrücke \"q\", um zu beenden. Der Seed ist {seed}, drücke \"c\" um zu Copiren.");
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

        static string[,] TreeGrow(string[,] forest, int width, int height, int w, int seed)
        {
            string[,] forestClone = (string[,])forest.Clone();
            Random random = new Random(seed);
            int probability;

            for (int i = 0; i < height; i++)
            {
                for (int i2 = 0; i2 < width; i2++)
                {
                    if (forestClone[i, i2] == "-f")
                    {
                        probability = random.Next(1, 101);
                        if (forest[i, Math.Max(0, Math.Min(i2 - 1, forest.GetLength(1) - 1))] == "W" || forest[i, Math.Max(0, Math.Min(i2 + 1, forest.GetLength(1) - 1))] == "W" || forest[Math.Max(0, Math.Min(i - 1, forest.GetLength(0) - 1)), i2] == "W" || forest[Math.Max(0, Math.Min(i + 1, forest.GetLength(0) - 1)), i2] == "W")
                        {
                            if (probability < Math.Max(w*10, 100))
                            {
                                forestClone[i, i2] = "b";
                            }
                        }
                        else
                        {
                            if (probability < w)
                            {
                                forestClone[i, i2] = "b";
                            }
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