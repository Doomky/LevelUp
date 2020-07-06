using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class UpdateFoodEntryRequestHandler : RequestHandler<UpdateFoodEntryDTORequest, UpdateFoodEntryDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodEntryRepository _foodEntryRepository;

        public UpdateFoodEntryRequestHandler(
            IUserRepository userRepository,
            IFoodEntryRepository foodEntryRepository,
            ClaimsPrincipal claims,
            UpdateFoodEntryDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _foodEntryRepository = foodEntryRepository;
        }

        protected override async Task<(UpdateFoodEntryDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            FoodEntry foodEntry = new FoodEntry()
            {
                Id = DTORequest.Id,
                Datetime = DTORequest.DateTime,
                OpenFoodFactsDataId = DTORequest.OFFDataId,
                UserId = user.Id
            };

            foodEntry = _foodEntryRepository.Update(foodEntry).GetAwaiter().GetResult();
            if (foodEntry == null)
                return (null, HttpStatusCode.BadRequest, "Could not update the given food entry, please check body data sanity");
            return (new UpdateFoodEntryDTOResponse(
                foodEntry.Id,
                foodEntry.UserId,
                foodEntry.OpenFoodFactsDataId,
                foodEntry.Datetime,
                foodEntry.Servings),
                HttpStatusCode.OK, null);
        }
    }
}
