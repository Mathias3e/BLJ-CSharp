using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aufagbe_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            do
            {
                WebRequest request = WebRequest.Create("https://witzapi.de/api/joke/");
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                string jsonData = new StreamReader(responseStream).ReadToEnd();

                JArray array = JArray.Parse(jsonData);

                Console.WriteLine("\n" + array[0].SelectToken("text"));

                Console.Write("\nNächster Witz holen? j/n ");
                input = Console.ReadLine();
            } while (input.ToLower() != "n");

            Console.ReadKey();
        }
    }
}
