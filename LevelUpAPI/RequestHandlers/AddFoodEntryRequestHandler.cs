using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

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
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            FoodEntry foodEntryData = _foodEntryRepository.Insert(new FoodEntry()
            {
                UserId = user.Id,
                OpenFoodFactsDataId = Request.OFFDataId,
                Datetime = DateTime.Now
            }).GetAwaiter().GetResult();

            if (foodEntryData != null)
            {
                var offData = _offDataRepository.Get(foodEntryData.OpenFoodFactsDataId).GetAwaiter().GetResult().FirstOrDefault();

                // update all quests based on datas
                var quests = _questRepository.Get(user, _questTypeRepository).GetAwaiter().GetResult();
                foreach (var quest in quests)
                {
                    var questHandler = QuestHandlers.Create(quest, _questTypeRepository);
                    questHandler.Update("Calories", (foodEntryData.Servings * offData.EnergyServing).ToString());
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
