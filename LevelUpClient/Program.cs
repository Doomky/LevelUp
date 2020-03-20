using IdentityModel.Client;
using LevelUpClient;
using LevelUpRequests;
using Newtonsoft.Json.Linq;

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
        public static async Task Main(string address = "localhost", string port = "5000")
        {
            string fullAddress = $"{HTTP}{address}:{port}";
            var client = new HttpClient();
            
            // call api
            while (true)
            {
                try
                {
                    Console.Write("port: ");
                    port = Console.ReadLine();
                    Console.Write("endpoint:");
                    string endpoint = Console.ReadLine();
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