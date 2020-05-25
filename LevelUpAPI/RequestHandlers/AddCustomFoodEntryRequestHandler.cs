using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class AddCustomFoodEntryRequestHandler : RequestHandler<AddCustomFoodEntryRequest>
    {
        private readonly IFoodEntryRepository _foodEntryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOFFDataRepository _oFFDataRepository;

        public AddCustomFoodEntryRequestHandler(IFoodEntryRepository foodEntryRepository, IUserRepository userRepository, IOFFDataRepository oFFDataRepository)
        {
            _foodEntryRepository = foodEntryRepository;
            _userRepository = userRepository;
            _oFFDataRepository = oFFDataRepository;
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

            FoodEntry foodEntry = _foodEntryRepository.Insert(new FoodEntry()
            {
                Datetime = DateTime.Now,
                UserId = user.Id,
                OpenFoodFactsDataId = offData.Id
            }).GetAwaiter().GetResult();
        }
    }
}
