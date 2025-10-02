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
            int seed;
            string input;

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

            Console.WriteLine(seed);

            Console.ReadKey();
        }
    }
}