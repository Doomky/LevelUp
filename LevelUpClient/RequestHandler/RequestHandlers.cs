using LevelUpClient.RequestHandler.Interfaces;
using LevelUpDTO;
using System;
using System.Net.Http;

namespace LevelUpClient.RequestHandler
{
    public static class RequestHandlers
    {
        public static void HandleEndpoint(HttpClient httpClient, string endpoint, string fulladdress)
        {
            IRequestHandler<DTORequest, DTOResponse> requestHandler;
            switch (endpoint)
            {
                // User
                case "users/signin":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new SignInRequestHandler(fulladdress);
                    break;
                case "users/signup":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new SignUpRequestHandler(fulladdress);
                    break;
                case "users/signout":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new SignOutRequestHandler(fulladdress);
                    break;
                case "users/forgot-password":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new ForgotPasswordRequestHandler(fulladdress);
                    break;
                case "users/change-password":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new ChangePasswordRequestHandler(fulladdress);
                    break;
                case "users/user-info":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new UserInfoRequestHandler(fulladdress);
                    break;
                case "users/change-user-info":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new ChangeUserInfoRequestHandler(fulladdress);
                    break;
                case "users/password-recovery":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new PasswordRecoveryRequestHandler(fulladdress);
                    break;
                case "users/link-google-account":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new LinkGoogleAccountRequestHandler(fulladdress);
                    break;
                case "users/google-access-token":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new AccessTokenInfoRequestHandler(fulladdress);
                    break;
                case "users/unlink-google-account":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new UnlinkGoogleAccountRequestHandler(fulladdress);
                    break;

                // OpenFoodFacts
                case "openfoodfactsdatas":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetOFFDataRequestHandler(fulladdress);
                    break;
                case "openfoodfactsdatas/category":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetOFFDataFromCategoryRequestHandler(fulladdress);
                    break;

                // FoodEntry
                case "foodentry":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetFoodEntriesRequestHandler(fulladdress);
                    break;
                case "foodentry/count":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetFoodEntriesCountRequestHandler(fulladdress);
                    break;
                case "foodentry/add/custom":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new AddCustomFoodEntryRequestHandler(fulladdress);
                    break;
                case "foodentry/add":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new AddFoodEntryRequestHandler(fulladdress);
                    break;
                case "foodentry/update":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new UpdateFoodEntryRequestHandler(fulladdress);
                    break;
                case "foodentry/remove":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new RemoveFoodEntryRequestHandler(fulladdress);
                    break;

                // Quest
                case "quests":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetQuestRequestHandler(fulladdress);
                    break;
                case "quests/category/list":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetQuestCategoriesRequestHandler(fulladdress);
                    break;
                case "quests/category":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetQuestByCategoryRequestHandler(fulladdress);
                    break;
                case "quests/type/list":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetQuestTypesRequestHandler(fulladdress);
                    break;
                case "quests/update":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new UpdateQuestRequestHandler(fulladdress);
                    break;
                case "quests/add":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new AddQuestRequestHandler(fulladdress);
                    break;
                case "quests/remove":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new RemoveQuestRequestHandler(fulladdress);
                    break;
                case "quests/claim":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new ClaimQuestsRequestHandler(fulladdress);
                    break;

                // Physical activities
                case "physicalactivities":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetPARequestHandler(fulladdress);
                    break;
                case "physicalactivities/add":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new AddPARequestHandler(fulladdress);
                    break;
                case "physicalactivities/entry":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetPAEntriesRequestHandler(fulladdress);
                    break;
                case "physicalactivities/entry/total":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetPAEntriesRequestHandler(fulladdress);
                    break;
                case "physicalactivities/entry/add":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new AddPAEntryRequestHandler(fulladdress);
                    break;
                case "physicalactivities/entry/update":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new UpdatePAEntryRequestHandler(fulladdress);
                    break;
                case "physicalactivities/entry/remove":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new RemovePAEntryRequestHandler(fulladdress);
                    break;

                // Avatar
                case "avatar":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new GetAvatarInfoRequestHandler(fulladdress);
                    break;
                case "avatar/update":
                    requestHandler = (IRequestHandler<DTORequest, DTOResponse>)new UpdateAvatarRequestHandler(fulladdress);
                    break;

                default:
                    Console.WriteLine("Unknown endpoint");
                    return;
            }
            DTOResponse DTOresponse = requestHandler.Handle(httpClient);
        }
    }
}
