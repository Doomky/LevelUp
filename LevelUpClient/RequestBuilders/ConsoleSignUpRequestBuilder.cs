using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient
{
    public class ConsoleSignUpRequestBuilder : RequestBuilder<SignUpRequest>
    {
        public ConsoleSignUpRequestBuilder WithLogin()
        {
            Console.Write("Login: ");
            Request.Login = Console.ReadLine();
            return this;
        }


        public ConsoleSignUpRequestBuilder WithFirstname()
        {
            Console.Write("Firstname:");
            Request.Firstname = Console.ReadLine();
            return this;
        }

        public ConsoleSignUpRequestBuilder WithLastname()
        {
            Console.Write("Lastname:");
            Request.Lastname = Console.ReadLine();
            return this;
        }

        public ConsoleSignUpRequestBuilder WithEmailAddress()
        {
            Console.Write("Email Adrress:");
            Request.EmailAddress = Console.ReadLine();
            return this;
        }

        public ConsoleSignUpRequestBuilder WithPasswordHash()
        {
            Console.Write("Password Hash:");
            Request.PasswordHash = Console.ReadLine();
            return this;
        }
    }
}
