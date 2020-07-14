using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
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

        public AddCustomFoodEntryRequestHandler(ClaimsPrincipal claims, AddCustomFoodEntryDTORequest dTORequest, ILogger logger, IFoodEntryRepository foodEntryRepository, IUserRepository userRepository, IOFFDataRepository oFFDataRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository) : base(claims, dTORequest, logger)
        {
            _foodEntryRepository = foodEntryRepository;
            _userRepository = userRepository;
            _oFFDataRepository = oFFDataRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
        }

        protected async override Task<(AddCustomFoodEntryDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            OpenFoodFactsData offData = await _oFFDataRepository.Insert(new OpenFoodFactsData()
            {

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
            });

            FoodEntry foodEntryData = await _foodEntryRepository.Insert(new FoodEntry()
            {
                Datetime = DateTime.Now,
                UserId = user.Id,
                OpenFoodFactsDataId = offData.Id
            });

            if (foodEntryData == null)
                return (null, HttpStatusCode.NoContent, null);

            var quests = await _questRepository.Get(user, _questTypeRepository, QuestState.InProgress);

            foreach (var quest in quests)
            {
                var questHandler = QuestHandlers.Create(quest, user, _questTypeRepository);
                questHandler.Update("Calories", (foodEntryData.Servings * offData.EnergyServing).ToString());
                await _questRepository.Update(quest);
            }

            AddCustomFoodEntryDTOResponse dtoResponse = new AddCustomFoodEntryDTOResponse(
                foodEntryData.Id,
                foodEntryData.UserId,
                foodEntryData.OpenFoodFactsDataId,
                foodEntryData.Datetime,
                foodEntryData.Servings
            );

            return (dtoResponse, HttpStatusCode.OK, null);
        }
    }
}
