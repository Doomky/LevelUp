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
            DiscoveryDocumentResponse discoDoc = null;

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
                Console.WriteLine("Please enter the Identity Server port:");
                port = Console.ReadLine();
                fullAddress = $"{HTTP}{address}:{port}";
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

            // call api
            while (true)
            {
                try
                {
                    Console.Write("port: ");
                    port = Console.ReadLine();
                    Console.Write("endpoint:");
                    string endpoint = Console.ReadLine();
                    Request request = ConsoleRequests.Create(endpoint);
                    if (request != null)
                    {
                        fullAddress = $"{HTTPS}{address}:{port}/{endpoint}";
                        Console.WriteLine(fullAddress);
                        string jsonString = JsonSerializer.Serialize<SignInRequest>((SignInRequest)request);
                        HttpContent httpContent = new StringContent(jsonString);
                        HttpResponseMessage httpResponse = await client.PostAsync(fullAddress, httpContent);
                        string bodyAsStr = "";
                        if (httpResponse.IsSuccessStatusCode)
                        {
                            bodyAsStr = await httpResponse.Content.ReadAsStringAsync();
                        }
                        Console.WriteLine(
$@"response:
status code: {(int)httpResponse.StatusCode} {httpResponse.StatusCode}
body: {bodyAsStr}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}