using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string input;
            int secretNumber, guess = 0, attempts;

            do
            {
                attempts = 0;
                secretNumber = random.Next(1, 101);
                do
                {
                    attempts++;

                    do
                    {
                        if (attempts == 1)
                        {
                            Console.WriteLine("Deine Zahl (1..100): ");
                        }
                        else if (guess < secretNumber && guess > 0)
                        {
                            Console.WriteLine("Zahl ist zu klein! Nächster Versuch: ");
                        }
                        else if (guess > secretNumber && guess < 101)
                        {
                            Console.WriteLine("Zahl ist zu gross! Nächster Versuch: ");
                        }
                        else if (guess > 100 || guess < 1)
                        {
                            Console.WriteLine("Ist kien oder Zahl ist nicht zwischen 1 und 100. Nächster Versuch: ");
                        }

                        input = Console.ReadLine();
                    } while (int.TryParse(input, out guess) == false);

                } while (guess != secretNumber);

                Console.WriteLine($"Die Zahl stimmt! Du hast total {attempts} Versuche benötigt. Noch einmal spielen? [y/n]");
                input = Console.ReadLine();

            } while (input.ToLower() == "y");

            Console.ReadKey();
        }
    }
}
