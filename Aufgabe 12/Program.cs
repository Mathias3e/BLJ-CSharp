using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Console.Write("--------------------\nZahlen Aufsummieren\n--------------------\n\n");
            Console.WriteLine("Geben Sie die zu summierenden Ganzzahlen mit Komma getrennt ein:");

            input = Console.ReadLine();
            int[] inputArray = input.Split(',').Select(int.Parse).ToArray();

            Console.WriteLine("\nResultat:");


            for (int i = 0; i < inputArray.Length; i++)
            {
                Console.Write($"[{i}] -> {SumUp(inputArray)[i]}");
                
                if (i != inputArray.Length-1)
                {
                    Console.Write(", ");
                }
            }

            Console.ReadKey();
        }

        static int[] SumUp(int[] arr)
        {
            int[] result = (int[])arr.Clone();

            for (int i = 1; i < arr.Length; i++)
            {
                result[i] += result[i - 1];
            }

            return result;
        }
    }
}
