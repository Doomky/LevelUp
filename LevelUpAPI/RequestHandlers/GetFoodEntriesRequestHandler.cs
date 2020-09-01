using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using static LevelUpDTO.GetFoodEntriesDTOResponse;

namespace LevelUpAPI.RequestHandlers
{
    public class GetFoodEntriesRequestHandler : RequestHandler<GetFoodEntriesDTORequest, GetFoodEntriesDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodEntryRepository _foodEntryRepository;
        private readonly IOFFDataRepository _OFFDataRepository;

        public GetFoodEntriesRequestHandler(ClaimsPrincipal claims, GetFoodEntriesDTORequest dTORequest, ILogger logger, IUserRepository userRepository, IFoodEntryRepository foodEntryRepository, IOFFDataRepository oFFDataRepository) : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _foodEntryRepository = foodEntryRepository;
            _OFFDataRepository = oFFDataRepository;
        }

        protected async override Task<(GetFoodEntriesDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            IEnumerable<FoodEntry> foodEntries = await _foodEntryRepository.GetFromUser(user.Login);

            if (foodEntries == null)
                return (null, HttpStatusCode.BadRequest, "Error while getting the list of food entries of the user");

            List<FoodEntryDTOResponse> foodEntryDTOs = new List<FoodEntryDTOResponse>();

            foreach (FoodEntry entry in foodEntries)
            {
                OpenFoodFactsData offData = await _OFFDataRepository.GetById(entry.OpenFoodFactsDataId);
                FoodEntryDTOResponse foodEntryDTO = new FoodEntryDTOResponse(
                    entry.Datetime,
                    entry.Servings,
                    offData.Code,
                    offData.Name,
                    offData.EnergyServing,
                    offData.SodiumServing,
                    offData.SaltServing,
                    offData.FatServing,
                    offData.SaturatedFatServing,
                    offData.ProteinsServing,
                    offData.SugarsServing,
                    offData.ImgUrl
                );
                foodEntryDTOs.Add(foodEntryDTO);
            }

            GetFoodEntriesDTOResponse dtoReponse = new GetFoodEntriesDTOResponse(foodEntryDTOs);

            return (dtoReponse, HttpStatusCode.OK, null);
        }
    }
}
