using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int[] calculation = new int[2];

            do
            {
                do
                {
                    Console.WriteLine("Make your calculation (or press Q to quit):");
                    input = Console.ReadLine();

                    if (input.ToLower() == "q") { return; }

                    try
                    {
                        calculation = input.Split('+', '-', '/', '*').Select(int.Parse).ToArray();
                        break;
                    }
                    catch { }
                } while (true);


                if (input.Contains('+'))
                {
                    Console.WriteLine(calculation[0] + calculation[1]);
                }
                else if (input.Contains('-'))
                {
                    Console.WriteLine(calculation[0] - calculation[1]);
                }
                else if (input.Contains('/'))
                {
                    Console.WriteLine(calculation[0] / calculation[1]);
                }
                else if (input.Contains('*'))
                {
                    Console.WriteLine(calculation[0] * calculation[1]);
                }
            } while (true);
        }
    }
}
