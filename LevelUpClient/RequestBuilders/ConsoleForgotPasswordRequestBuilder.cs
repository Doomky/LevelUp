using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleForgotPasswordRequestBuilder : RequestBuilder<ForgotPasswordRequest>
    {
        public ConsoleForgotPasswordRequestBuilder WithLogin()
        {
            Console.WriteLine("Login: ");
            Request.Login = Console.ReadLine();
            return this;
        }

        public ConsoleForgotPasswordRequestBuilder WithEmailAddress()
        {
            Console.WriteLine("Email Address: ");
            Request.EmailAddress = Console.ReadLine();
            return this;
        }
    }
}
