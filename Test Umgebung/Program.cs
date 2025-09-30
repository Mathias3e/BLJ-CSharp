using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Umgebung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("This text will be cleared.");
                Console.ReadLine(); // Wait for user input before clearing
                Console.Clear();    // Clears the console
                Console.WriteLine("Console has been cleared!");
            }
        }
    }
}
