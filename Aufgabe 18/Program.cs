using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aufgabe_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            char[] vocal = { 'a', 'e', 'i', 'o', 'u', 'ä', 'ö', 'ü', 'A', 'E', 'I', 'O', 'U', 'Ä', 'Ö', 'Ü' };
            int index;

            Console.WriteLine("Deine Eingabe:");
            input = Console.ReadLine();

            for (int i = 0; i < vocal.Length; i++)
            {
                if (input.Contains(vocal[i]))
                {
                    index = input.Count(character => character == vocal[i]);
                    Console.WriteLine($"Der Buchstabe \'{vocal[i]}\' kommt {index} mal vor.");
                }
            }

            Console.ReadKey();
        }
    }
}
