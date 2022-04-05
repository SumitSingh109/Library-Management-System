using Library_Management_System.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace Consume_API
{
    class Program
    {
        static void Main(string[] args)
        {
            //send http request to fetch the value

            CreateBookEntry();
        }

        public static Catalogue CreateBookEntry()
        {
            HttpWebRequest request = WebRequest.Create("https://localhost:44315/api/Book/Create") as HttpWebRequest;

            //store the respose
            string jsonValue = "";

            //recieve the response from the API
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonValue = reader.ReadToEnd();
            }

            // Initialize class to store the response
            Catalogue result = JsonConvert.DeserializeObject<Catalogue>(jsonValue);

            //Print the current rate of the bitcoin
            //Console.Write("The current price of Bitcoin in Europe is:" + result);
            //Console.ReadKey();

            return result;

        }
    }
    }
}
