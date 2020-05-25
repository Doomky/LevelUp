using LevelUpRequests;
using System;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleSignOutRequestBuilder : RequestBuilder<SignOutRequest>
    {
        public ConsoleSignOutRequestBuilder WithAccessToken()
        {
            Console.Write("Access Token:");
            Request.AccessToken = Console.ReadLine();
            return this;
        }
    }
}
