using IdentityModel;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient
{
    public class ConsoleSignInRequestBuilder : RequestBuilder<SignInRequest>
    {
        public ConsoleSignInRequestBuilder WithLogin()
        {
            Console.Write("Login:");
            Request.Login = Console.ReadLine();
            return this;
        }

        public ConsoleSignInRequestBuilder WithEmailAddress()
        {
            Console.Write("Email Address:");
            Request.EmailAddress = Console.ReadLine();
            return this;
        }

        public ConsoleSignInRequestBuilder WithPassword()
        {
            Console.Write("Password (will be hashed):");
            Request.PasswordHash = Console.ReadLine().ToSha256();
            return this;
        }

        public ConsoleSignInRequestBuilder WithPasswordHash()
        {
            Console.Write("Password Hash:");
            Request.PasswordHash = Console.ReadLine();
            return this;
        }

    }
}
