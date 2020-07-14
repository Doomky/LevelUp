using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class RemoveFoodEntryRequestHandler : RequestHandler<RemoveFoodEntryDTORequest, RemoveFoodEntryDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodEntryRepository _foodEntryRepository;

        public RemoveFoodEntryRequestHandler(ClaimsPrincipal claims, RemoveFoodEntryDTORequest dtoRequest, ILogger logger, IUserRepository userRepository, IFoodEntryRepository foodEntryRepository) : base(claims, dtoRequest, logger)
        {
            _userRepository = userRepository;
            _foodEntryRepository = foodEntryRepository;
        }

        protected async override Task<(RemoveFoodEntryDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode errStatusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, errStatusCode, err);

            FoodEntry foodEntry = _foodEntryRepository.GetFoodEntryById(DTORequest.Id);
            if (foodEntry == null)
                return (null, HttpStatusCode.BadRequest, "Could not find the food entry, please check body data sanity");
            
            if (! await _foodEntryRepository.Delete(DTORequest.Id))
                return (null, HttpStatusCode.BadRequest, "Could not remove the food entry");

            return (new RemoveFoodEntryDTOResponse(DTORequest.Id), HttpStatusCode.OK, null);
        }
    }
}
