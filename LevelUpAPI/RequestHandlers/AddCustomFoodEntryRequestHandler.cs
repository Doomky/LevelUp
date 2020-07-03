using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class AddCustomFoodEntryRequestHandler : RequestHandler<AddCustomFoodEntryDTORequest, AddCustomFoodEntryDTOResponse>
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

        protected override async Task<AddCustomFoodEntryDTOResponse> ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(DTORequest, context, _userRepository);
            if (!isOk || user == null)
                return null;

            OpenFoodFactsData offData = _oFFDataRepository.Insert(new OpenFoodFactsData() { 

                Name = DTORequest.Name,
                IsCustom = true,
                // 100g
                Energy100g = DTORequest.Energy100g,
                Proteins100g = DTORequest.Proteins100g,
                Sodium100g = DTORequest.Sodium100g,
                Fat100g = DTORequest.Fat100g,
                Salt100g = DTORequest.Salt100g,
                SaturatedFat100g = DTORequest.SaturatedFat100g,
                Sugars100g = DTORequest.Sugars100g,
                // Serving
                EnergyServing = DTORequest.EnergyServing,
                ProteinsServing = DTORequest.ProteinsServing,
                SodiumServing = DTORequest.SodiumServing,
                FatServing = DTORequest.FatServing,
                SaltServing = DTORequest.SaltServing,
                SaturatedFatServing = DTORequest.SaturatedFatServing,
                SugarsServing = DTORequest.SugarsServing,
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
                var quests = _questRepository.Get(user, _questTypeRepository, QuestState.InProgress).GetAwaiter().GetResult();
                foreach (var quest in quests)
                {
                    var questHandler = QuestHandlers.Create(quest, user, _questTypeRepository);
                    questHandler.Update("Calories", (foodEntryData.Servings * offData.EnergyServing).ToString());
                    _questRepository.Update(quest).GetAwaiter().GetResult();
                }

                string foodEntryJson = JsonSerializer.Serialize(foodEntryData);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(foodEntryJson).GetAwaiter().GetResult();
                return JsonSerializer.Deserialize<AddCustomFoodEntryDTOResponse>(foodEntryJson);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return null;
            }
        }
    }
}
