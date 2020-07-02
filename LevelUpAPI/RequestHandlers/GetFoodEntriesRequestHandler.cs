using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class GetFoodEntriesRequestHandler : RequestHandler<GetFoodEntriesDTORequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodEntryRepository _foodEntryRepository;
        private readonly IOFFDataRepository _OFFDataRepository;

        public GetFoodEntriesRequestHandler(IUserRepository userRepository, IFoodEntryRepository foodEntryRepository, IOFFDataRepository oFFDataRepository)
        {
            _userRepository = userRepository;
            _foodEntryRepository = foodEntryRepository;
            _OFFDataRepository = oFFDataRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            IEnumerable<FoodEntry> foodEntries = _foodEntryRepository.GetFromUser(user.Login).GetAwaiter().GetResult();

            List<FoodEntryData> foodEntryDatas = new List<FoodEntryData>();
            foreach (FoodEntry entry in foodEntries)
                foodEntryDatas.Add(new FoodEntryData(entry, _OFFDataRepository.GetById(entry.OpenFoodFactsDataId).GetAwaiter().GetResult()));
            
            if (foodEntries != null)
            {
                string foodEntriesJson = JsonSerializer.Serialize(foodEntryDatas);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(foodEntriesJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
