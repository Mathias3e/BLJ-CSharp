using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

            string jsonString = JsonSerializer.Serialize(contact, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("contacts.json", jsonString);


            Console.ReadKey();
        }
    }
}
