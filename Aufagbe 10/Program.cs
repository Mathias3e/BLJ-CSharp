using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufagbe_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int UserNumber;

            do
            {
                Console.Write("Zahl: ");
                input = Console.ReadLine();
            } while (int.TryParse(input, out UserNumber) == false);

            Console.Write($"Die Quersumme von {UserNumber} ist: {BerechneQuersumme(UserNumber)}");

            Console.ReadKey();
        }
        static int BerechneQuersumme(int zahl)
        {
            int sum = 0;

            while (zahl != 0)
            {
                sum = sum + (zahl % 10);
                zahl /= 10;
            }

            return sum;
        }
    }
}
