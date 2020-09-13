using LevelUpClient.RequestHandler.Interfaces;
using System;
using System.Net.Http;

namespace LevelUpClient.RequestHandler
{
    public static class RequestHandlers
    {
        public static void HandleEndpoint(HttpClient httpClient, string endpoint, string fulladdress)
        {
            IRequestHandler requestHandler;
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
                case "users/google-access-token":
                    requestHandler = new AccessTokenInfoRequestHandler(fulladdress);
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
                case "quests/category/list":
                    requestHandler = new GetQuestCategoriesRequestHandler(fulladdress);
                    break;
                case "quests/category":
                    requestHandler = new GetQuestByCategoryRequestHandler(fulladdress);
                    break;
                case "quests/type/list":
                    requestHandler = new GetQuestTypesRequestHandler(fulladdress);
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
                    requestHandler = new GetPARequestHandler(fulladdress);
                    break;
                case "physicalactivities/add":
                    requestHandler = new AddPARequestHandler(fulladdress);
                    break;
                case "physicalactivities/entry":
                    requestHandler = new GetPAEntriesRequestHandler(fulladdress);
                    break;
                case "physicalactivities/entry/total":
                    requestHandler = new GetPAEntriesRequestHandler(fulladdress);
                    break;
                case "physicalactivities/entry/add":
                    requestHandler = new AddPAEntryRequestHandler(fulladdress);
                    break;
                case "physicalactivities/entry/update":
                    requestHandler = new UpdatePAEntryRequestHandler(fulladdress);
                    break;
                case "physicalactivities/entry/remove":
                    requestHandler = new RemovePAEntryRequestHandler(fulladdress);
                    break;

                // Avatar
                case "avatar":
                    requestHandler = new GetAvatarInfoRequestHandler(fulladdress);
                    break;
                case "avatar/update":
                    requestHandler = new UpdateAvatarRequestHandler(fulladdress);
                    break;
                case "avatar/skin":
                    requestHandler = new GetCurrentSkinRequestHandler(fulladdress);
                    break;
                case "avatar/skin/all":
                    requestHandler = new GetAllSkinsRequestHandler(fulladdress);
                    break;
                case "avatar/skin/available":
                    requestHandler = new GetAvailableSkinsRequestHandler(fulladdress);
                    break;
                case "avatar/skin/select":
                    requestHandler = new SelectSkinRequestHandler(fulladdress);
                    break;

                // Sleep
                case "sleep":
                    requestHandler = new GetSleepEntriesRequestHandler(fulladdress);
                    break;

                //Advices
                case "advice":
                    requestHandler = new GetAdviceByCategoryRequestHandler(fulladdress);
                    break;
                case "advice/all":
                    requestHandler = new GetAllAdvicesRequestHandler(fulladdress);
                    break;
                default:
                    Console.WriteLine("Unknown endpoint");
                    return;
            }
            requestHandler.Handle(httpClient);
        }
    }
}
