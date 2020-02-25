using IdentityModel.Client;
using Newtonsoft.Json.Linq;

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpClient
{
    class Program
    {
        /// <summary>
        /// Client to test LevelUp API
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static async Task Main(string address = "http://localhost", string port = "5000")
        {
            string fullAddress = address + ":" + port;

            var client = new HttpClient();
            DiscoveryDocumentResponse discoDoc = null;

            do
            {
                do
                {
                    try
                    {
                        discoDoc = await client.GetDiscoveryDocumentAsync(fullAddress);
                        if (discoDoc.IsError)
                        {
                            Console.WriteLine($"Discovery Document:\n { discoDoc.Error }");
                        }
                        else
                        {
                            Console.WriteLine($"Discovery Document:\n { discoDoc.HttpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult() }");
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                    }

                    discoDoc = null;
                    Console.WriteLine("Please enter the port: ");
                    port = Console.ReadLine();
                    fullAddress = address + ":" + port;
                } while (discoDoc == null);


                // request token
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = discoDoc.TokenEndpoint,
                    ClientId = "client",
                    ClientSecret = "secret",
                    Scope = "api1"
                });

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                    return;
                }
                
                client.SetBearerToken(tokenResponse.AccessToken);

                Console.WriteLine(
                    @$"token response:
                    access token: {tokenResponse.AccessToken}
                    identity token: {tokenResponse.IdentityToken}
                    expire in: {tokenResponse.ExpiresIn}");

            } while (Console.ReadKey().Key != ConsoleKey.Enter);


            // call api

            while (true)
            {
                address = "https://localhost";
                try
                {
                    Console.WriteLine("enter the port: ");
                    port = Console.ReadLine();
                    Console.WriteLine("enter the endpoint to access: ");
                    string endpoint = Console.ReadLine();
                    await GetRequest(client, address, port, endpoint);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public static async Task GetRequest(HttpClient client, string address, string port, string endpoint)
        {
            string url = $"{address}:{port}/{endpoint}";
            Console.WriteLine($"{url} response:"); 
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{response.StatusCode}");
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"{response.StatusCode}\n {content}");
            }
        }
    }
}
