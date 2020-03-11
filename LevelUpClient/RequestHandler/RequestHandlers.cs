﻿using LevelUpClient.RequestHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public static class RequestHandlers
    {
        public static void HandleEndpoint(HttpClient httpClient, string endpoint, string fulladrress)
        {
            IRequestHandler requestHandler = null;
            switch (endpoint)
            {
                case "users/signin":
                    requestHandler = new SignInRequestHandler(fulladrress);
                    break;
                case "users/signup":
                    requestHandler = new SignUpRequestHandler(fulladrress);
                    break;
                case "users/signout":
                    requestHandler = new SignOutRequestHandler(fulladrress);
                    break;
                case "users/change-password":
                    requestHandler = new ChangePasswordRequestHandler(fulladrress);
                    break;
                default:
                    Console.WriteLine("Unknown endpoint");
                    return;
            }
            requestHandler.Handle(httpClient);
        }
    }
}