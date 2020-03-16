﻿using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleSetGoogleIdRequestBuilder : RequestBuilder<SetGoogleIdTokenRequest>
    {
        public ConsoleSetGoogleIdRequestBuilder WithGoogleId()
        {
            Console.Write("Google Id:");
            Request.GoogleIdToken = Console.ReadLine();
            return this;
        }
    }
}
