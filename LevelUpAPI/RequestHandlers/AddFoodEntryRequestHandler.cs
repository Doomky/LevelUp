using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler.QuestState;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace LevelUpAPI.RequestHandlers
{
    public class AddFoodEntryRequestHandler : RequestHandler<AddFoodEntryDTORequest, AddFoodEntryDTOResponse>
    {
        private readonly IFoodEntryRepository _foodEntryRepository;
        private readonly IOFFDataRepository _offDataRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly IUserRepository _userRepository;

        public AddFoodEntryRequestHandler(ClaimsPrincipal claims, AddFoodEntryDTORequest dtoRequest, ILogger logger, IFoodEntryRepository foodEntryRepository, IOFFDataRepository offDataRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository, IUserRepository userRepository) : base(claims, dtoRequest, logger)
        {
            _foodEntryRepository = foodEntryRepository;
            _offDataRepository = offDataRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
            _userRepository = userRepository;
        }

        protected async override Task<(AddFoodEntryDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            FoodEntry foodEntryData = await _foodEntryRepository.Insert(new FoodEntry()
            {
                UserId = user.Id,
                OpenFoodFactsDataId = DTORequest.OFFDataId,
                Datetime = DateTime.Now
            });

            if (foodEntryData == null)
                return (null, HttpStatusCode.NoContent, null);
            
            var offData = (await _offDataRepository.Get(foodEntryData.OpenFoodFactsDataId)).FirstOrDefault();

            // update all quests based on datas
            var quests = await _questRepository.Get(user, _questTypeRepository, InProgress);
            foreach (var quest in quests)
            {
                var questHandler = QuestHandlers.Create(quest, user, _questTypeRepository);
                questHandler.Update("Calories", (foodEntryData.Servings * offData.EnergyServing).ToString());
                await _questRepository.Update(quest);
            }

            AddFoodEntryDTOResponse dtoResponse = new AddFoodEntryDTOResponse(foodEntryData.Id, foodEntryData.UserId, foodEntryData.OpenFoodFactsDataId, foodEntryData.Datetime, foodEntryData.Servings);

            return (dtoResponse, HttpStatusCode.OK, null);
        }
    }
}
