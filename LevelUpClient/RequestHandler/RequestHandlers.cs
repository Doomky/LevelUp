using LevelUpClient.RequestHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public static class RequestHandlers
    {
        public static void HandleEndpoint(HttpClient httpClient, string endpoint, string fulladdress)
        {
            IRequestHandler requestHandler = null;
            switch (endpoint)
            {
                case "users/signin":
                    requestHandler = new SignInRequestHandler(fulladdress);
                    break;
                case "users/signup":
                    requestHandler = new SignUpRequestHandler(fulladdress);
                    break;
                case "users/signout":
                    requestHandler = new SignOutRequestHandler(fulladdress);
                    break;
                case "users/change-password":
                    requestHandler = new ChangePasswordRequestHandler(fulladdress);
                    break;
                case "users/user-info":
                    requestHandler = new UserInfoRequestHandler(fulladdress);
                    break;
                case "users/change-user-info":
                    requestHandler = new ChangeUserInfoRequestHandler(fulladdress);
                    break;
                case "users/google-id-token/set":
                    requestHandler = new SetGoogleIdTokenRequestHandler(fulladdress);
                    break;
                case "users/google-id-token/remove":
                    requestHandler = new RemoveGoogleIdRequestHandler(fulladdress);
                    break;
                case "openfoodfactsdatas":
                    requestHandler = new GetOFFDataRequestHandler(fulladdress);
                    break;
                case "foodentry/add":
                    requestHandler = new AddFoodEntryRequestHandler(fulladdress);
                    break;
                case "foodentry/update":
                    requestHandler = new UpdateFoodEntryRequestHandler(fulladrress);
                    break;
                default:
                    Console.WriteLine("Unknown endpoint");
                    return;
            }
            requestHandler.Handle(httpClient);
        }
    }
}
