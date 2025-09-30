using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kür_Waldbrand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int probability;

            for (int i = 0; i <= 10; i++)
            {
                for (int i2 = 0; i2 <= 10; i2++)
                {
                    probability = random.Next(1, 101);

                    if (probability <= 25)
                    {
                        Console.Write("B");
                    }
                    else if (probability > 25 && probability <= 50)
                    {
                        Console.Write("S");
                    }
                    else if (probability > 50 && probability <= 100)
                    {
                        Console.Write("-");
                    }
                }
                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }
}
