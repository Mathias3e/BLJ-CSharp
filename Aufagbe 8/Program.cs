using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufagbe_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] forbiddenWords = {"viagra", "sex", "porno", "fick", "schlampe", "arsch", "nackt", "pornos", "masturbation", "pornoindustrie", "ficken", "sexuell", "orgasmus", "erotik", "pornografisch", "geil", "arschloch"};
            string input;
            int count = 0;

            Console.WriteLine("Dein Kommentar:");
            input = Console.ReadLine();

            for (int i = 0; i < forbiddenWords.Length; i++)
            {
                if (input.Contains(forbiddenWords[i]))
                {
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("\nVielen Dank für deinen Kommentar.");
            } else
            {
                Console.WriteLine($"\nDein Kommentar enthält {count} verbotene Wörter.\nEr wird nicht veröffentlicht.");
            }

            Console.ReadKey();
        }
    }
}
