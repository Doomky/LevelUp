using IdentityModel;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleChangePasswordRequestBuilder : RequestBuilder<ChangePasswordRequest>
    {
        public ConsoleChangePasswordRequestBuilder WithPassword()
        {
            Console.Write("Password (will be hashed): ");
            Request.PasswordHash = Console.ReadLine().ToSha256();
            return this;
        }

        public ConsoleChangePasswordRequestBuilder WithPasswordHash()
        {
            Console.Write("Password Hash: ");
            Request.PasswordHash = Console.ReadLine();
            return this;
        }

        public ConsoleChangePasswordRequestBuilder WithNewPassword()
        {
            Console.Write("New Password (will be hashed): ");
            Request.NewPasswordHash = Console.ReadLine().ToSha256();
            return this;
        }

        public ConsoleChangePasswordRequestBuilder WithNewPasswordHash()
        {
            Console.Write("New Password Hash: ");
            Request.NewPasswordHash = Console.ReadLine();
            return this;
        }
    }
}
