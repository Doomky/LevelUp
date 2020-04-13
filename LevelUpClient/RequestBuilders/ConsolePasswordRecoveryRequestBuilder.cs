using IdentityModel;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsolePasswordRecoveryRequestBuilder : RequestBuilder<PasswordRecoveryRequest>
    {
        public ConsolePasswordRecoveryRequestBuilder WithPassword()
        {
            Console.Write("Password (will be hashed): ");
            Request.PasswordHash = Console.ReadLine().ToSha256();
            return this;
        }

        public ConsolePasswordRecoveryRequestBuilder WithPasswordHash()
        {
            Console.Write("Password Hash: ");
            Request.PasswordHash = Console.ReadLine();
            return this;
        }

        public ConsolePasswordRecoveryRequestBuilder WithHash()
        {
            Console.Write("Hash: ");
            Request.Hash = Console.ReadLine();
            return this;
        }
    }
}
