using LevelUpClient;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient
{
    public class SignUpRequestBuilder : RequestBuilder<SignUpRequest>
    {
        public SignUpRequestBuilder WithLogin(string login)
        {
            Request.Login = login;
            return this;
        }


        public SignUpRequestBuilder WithFirstname(string firstname)
        {
            Request.Firstname = firstname;
            return this;
        }

        public SignUpRequestBuilder WithLastname(string lastname)
        {
            Request.Lastname = lastname;
            return this;
        }

        public SignUpRequestBuilder WithEmailAddress(string emailAdrress)
        {
            Request.EmailAddress = emailAdrress;
            return this;
        }

        public SignUpRequestBuilder WithPasswordHash(string passwordHash)
        {
            Request.PasswordHash = passwordHash;
            return this;
        }
    }
}
