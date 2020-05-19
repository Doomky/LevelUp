using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LevelUpClient
{
    class Program
    {
        public static readonly string HTTP = "http://";
        public static readonly string HTTPS = "https://";

        /// <summary>
        /// Client to test LevelUp API
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static async Task Main(string address = "localhost", string port = "44381")
        {
            string endpoint;
            string fullAddress;

            var client = new HttpClient();

            //Console.Write("port: ");
            //port = Console.ReadLine();

            // call api
            while (true)
            {
                try
                {
                    Console.Write("endpoint:");
                    endpoint = Console.ReadLine();
                    fullAddress = $"{HTTPS}{address}:{port}/{endpoint}";
                    RequestHandler.RequestHandlers.HandleEndpoint(client, endpoint, fullAddress);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}