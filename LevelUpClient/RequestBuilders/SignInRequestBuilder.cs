using LevelUpClient;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient
{
    public class SignInRequestBuilder : RequestBuilder<SignInRequest>
    {
        public SignInRequestBuilder WithLogin(string login)
        {
            Request.Login = login;
            return this;
        }

        public SignInRequestBuilder WithEmailAddress(string emailAdrress)
        {
            Request.EmailAddress = emailAdrress;
            return this;
        }

        public SignInRequestBuilder WithPasswordHash(string passwordHash)
        {
            Request.PasswordHash = passwordHash;
            return this;
        }
    }
}
