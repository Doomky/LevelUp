using LevelUpDTO;
using System;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleSignOutRequestBuilder : RequestBuilder<SignOutDTORequest>
    {
        public ConsoleSignOutRequestBuilder WithAccessToken()
        {
            Console.Write("Access Token:");
            Request.AccessToken = Console.ReadLine();
            return this;
        }
    }
}
