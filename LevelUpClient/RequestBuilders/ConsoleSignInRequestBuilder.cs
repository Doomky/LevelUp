using IdentityModel;
using LevelUpRequests;
using System;
using System.Net.Mail;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleSignInRequestBuilder : RequestBuilder<SignInRequest>
    {
        public ConsoleSignInRequestBuilder WithLoginOrEmailAddress()
        {
            Console.Write("Login or Email Address:");
            string result = Console.ReadLine();
            try
            {
                MailAddress mailAddress = new MailAddress(result);
                Request.EmailAddress = mailAddress.Address;
            }
            catch (FormatException)
            {
                Request.Login = result;
            }
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
