using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleChangeUserInfoRequestBuilder : RequestBuilder<ChangeUserInfoRequest>
    {
        public ConsoleChangeUserInfoRequestBuilder WithNewFirstname()
        {
            Console.Write("New Firstname (empty if no change): ");
            Request.NewFirstname = Console.ReadLine();
            return this;
        }

        public ConsoleChangeUserInfoRequestBuilder WithNewLastname()
        {
            Console.Write("New Lastname (empty if no change): ");
            Request.NewLastname = Console.ReadLine();
            return this;
        }

        public ConsoleChangeUserInfoRequestBuilder WithNewEmail()
        {
            Console.Write("New Email (empty if no change): ");
            Request.NewEmail = Console.ReadLine();
            return this;
        }
    }
}
