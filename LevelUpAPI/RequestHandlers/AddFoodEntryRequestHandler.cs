using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class AddFoodEntryRequestHandler : RequestHandler<AddFoodEntryRequest>
    {
        private readonly IFoodEntryRepository _foodEntryRepository;
        private readonly IOFFDataRepository _offDataRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly IUserRepository _userRepository;

        public AddFoodEntryRequestHandler(IFoodEntryRepository foodEntryRepository, IOFFDataRepository offDataRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository, IUserRepository userRepository)
        {
            _foodEntryRepository = foodEntryRepository;
            _offDataRepository = offDataRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            ClaimsPrincipal claims = context.User;

            if (claims == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsync("no claims").GetAwaiter().GetResult();
                return;
            }

            Dbo.User user = _userRepository.GetUserByClaims(claims).GetAwaiter().GetResult();

            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("no user for this client_id").GetAwaiter().GetResult();
                return;
            }

            FoodEntry foodEntryData = _foodEntryRepository.Insert(new FoodEntry()
            {
                UserId = Request.UserId,
                OpenFoodFactsDataId = Request.OFFDataId,
                Datetime = DateTime.Now
            }).GetAwaiter().GetResult();

            if (foodEntryData != null)
            {
                var offData = _offDataRepository.Get(foodEntryData.OpenFoodFactsDataId).GetAwaiter().GetResult().FirstOrDefault();

                // update all quests based on datas
                var quests = _questRepository.Get(user).GetAwaiter().GetResult();
                foreach (var quest in quests)
                {
                    var questHandler = QuestHandlers.Create(quest, _questTypeRepository);
                    questHandler.Update("Calories", offData.EnergyServing.ToString());
                    _questRepository.Update(quest).GetAwaiter().GetResult();
                }

                string foodEntryJson = JsonSerializer.Serialize(foodEntryData);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(foodEntryJson).GetAwaiter().GetResult();
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
            }
        }
    }
}
