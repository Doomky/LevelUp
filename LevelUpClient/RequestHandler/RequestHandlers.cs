﻿using LevelUpClient.RequestHandler.Interfaces;
using System;
using System.Net.Http;

namespace LevelUpClient.RequestHandler
{
    public static class RequestHandlers
    {
        public static void HandleEndpoint(HttpClient httpClient, string endpoint, string fulladdress)
        {
            IRequestHandler requestHandler = null;
            switch (endpoint)
            {
                // User
                case "users/signin":
                    requestHandler = new SignInRequestHandler(fulladdress);
                    break;
                case "users/signup":
                    requestHandler = new SignUpRequestHandler(fulladdress);
                    break;
                case "users/signout":
                    requestHandler = new SignOutRequestHandler(fulladdress);
                    break;
                case "users/forgot-password":
                    requestHandler = new ForgotPasswordRequestHandler(fulladdress);
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
                case "users/password-recovery":
                    requestHandler = new PasswordRecoveryRequestHandler(fulladdress);
                    break;
                case "users/link-google-account":
                    requestHandler = new LinkGoogleAccountRequestHandler(fulladdress);
                    break;
                case "users/unlink-google-account":
                    requestHandler = new UnlinkGoogleAccountRequestHandler(fulladdress);
                    break;

                // OpenFoodFacts
                case "openfoodfactsdatas":
                    requestHandler = new GetOFFDataRequestHandler(fulladdress);
                    break;
                case "openfoodfactsdatas/category":
                    requestHandler = new GetOFFDataFromCategoryRequestHandler(fulladdress);
                    break;

                // FoodEntry
                case "foodentry":
                    requestHandler = new GetFoodEntriesRequestHandler(fulladdress);
                    break;
                case "foodentry/count":
                    requestHandler = new GetFoodEntriesCountRequestHandler(fulladdress);
                    break;
                case "foodentry/add/custom":
                    requestHandler = new AddCustomFoodEntryRequestHandler(fulladdress);
                    break;
                case "foodentry/add":
                    requestHandler = new AddFoodEntryRequestHandler(fulladdress);
                    break;
                case "foodentry/update":
                    requestHandler = new UpdateFoodEntryRequestHandler(fulladdress);
                    break;
                case "foodentry/remove":
                    requestHandler = new RemoveFoodEntryRequestHandler(fulladdress);
                    break;

                // Quest
                case "quests":
                    requestHandler = new GetQuestRequestHandler(fulladdress);
                    break;
                case "quests/category":
                    requestHandler = new GetQuestByCategoryRequestHandler(fulladdress);
                    break; 
                case "quests/update":
                    requestHandler = new UpdateQuestRequestHandler(fulladdress);
                    break;
                case "quests/add":
                    requestHandler = new AddQuestRequestHandler(fulladdress);
                    break;
                case "quests/remove":
                    requestHandler = new RemoveQuestRequestHandler(fulladdress);
                    break;
                case "quests/claim":
                    requestHandler = new ClaimQuestsRequestHandler(fulladdress);
                    break;

                // Physical activities
                case "physicalactivities":
                    requestHandler = new GetPAEntriesRequestHandler(fulladdress);
                    break;
                case "physicalactivities/add":
                    requestHandler = new AddPAEntryRequestHandler(fulladdress);
                    break;
                case "physicalactivities/update":
                    requestHandler = new UpdatePAEntryRequestHandler(fulladdress);
                    break;
                case "physicalactivities/remove":
                    requestHandler = new RemovePAEntryRequestHandler(fulladdress);
                    break;

                default:
                    Console.WriteLine("Unknown endpoint");
                    return;
            }
            requestHandler.Handle(httpClient);
        }
    }
}
