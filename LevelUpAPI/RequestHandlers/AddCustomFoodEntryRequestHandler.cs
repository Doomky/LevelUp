using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class AddCustomFoodEntryRequestHandler : RequestHandler<AddCustomFoodEntryRequest>
    {
        private readonly IFoodEntryRepository _foodEntryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOFFDataRepository _oFFDataRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;

        public AddCustomFoodEntryRequestHandler(IFoodEntryRepository foodEntryRepository, IUserRepository userRepository, IOFFDataRepository oFFDataRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository)
        {
            _foodEntryRepository = foodEntryRepository;
            _userRepository = userRepository;
            _oFFDataRepository = oFFDataRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            OpenFoodFactsData offData = _oFFDataRepository.Insert(new OpenFoodFactsData() { 

                Name = Request.Name,
                IsCustom = true,
                // 100g
                Energy100g = Request.Energy100g,
                Proteins100g = Request.Proteins100g,
                Sodium100g = Request.Sodium100g,
                Fat100g = Request.Fat100g,
                Salt100g = Request.Salt100g,
                SaturatedFat100g = Request.SaturatedFat100g,
                Sugars100g = Request.Sugars100g,
                // Serving
                EnergyServing = Request.EnergyServing,
                ProteinsServing = Request.ProteinsServing,
                SodiumServing = Request.SodiumServing,
                FatServing = Request.FatServing,
                SaltServing = Request.SaltServing,
                SaturatedFatServing = Request.SaturatedFatServing,
                SugarsServing = Request.SugarsServing,
            }).GetAwaiter().GetResult();

            FoodEntry foodEntryData = _foodEntryRepository.Insert(new FoodEntry()
            {
                Datetime = DateTime.Now,
                UserId = user.Id,
                OpenFoodFactsDataId = offData.Id
            }).GetAwaiter().GetResult();

            if (foodEntryData != null)
            {
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
