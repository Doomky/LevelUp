using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient
{
    public static class ConsoleRequests
    {
        public static Request Create(string endpoint)
        {
            switch (endpoint)
            {
                case "users/signin":
                    return new ConsoleSignInRequestBuilder()
                            .WithLogin()
                            .WithEmailAddress()
                            .WithPasswordHash()
                            .Build();
                case "users/signup":
                    return new ConsoleSignUpRequestBuilder()
                            .WithLogin()
                            .WithFirstname()
                            .WithLastname()
                            .WithEmailAddress()
                            .WithPasswordHash()
                            .Build();
                default:
                    return null;
            }
        }
    }
}
