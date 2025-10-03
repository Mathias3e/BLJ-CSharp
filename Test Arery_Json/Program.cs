using System;
using System.Collections.Generic;

namespace Test_Array_Json
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string[]> contact = new List<string[]>();

            contact.Add(new string[] { "1", "a", "#" });
            contact.Add(new string[] { "2", "b", "@" });

            Console.Write(contact[1][1]);

            Console.ReadKey();
        }
    }
}
