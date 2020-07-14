using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Security.Claims;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using static LevelUpDTO.GetFoodEntriesCountDTOResponse;

namespace LevelUpAPI.RequestHandlers
{
    public class GetFoodEntriesCountRequestHandler : RequestHandler<GetFoodEntriesCountDTORequest, GetFoodEntriesCountDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodEntryRepository _foodEntryRepository;

        public GetFoodEntriesCountRequestHandler(ClaimsPrincipal claims, GetFoodEntriesCountDTORequest dtoRequest, ILogger logger, IUserRepository userRepository, IFoodEntryRepository foodEntryRepository) : base(claims, dtoRequest, logger)
        {
            _userRepository = userRepository;
            _foodEntryRepository = foodEntryRepository;
        }

        protected async override Task<(GetFoodEntriesCountDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            List<NbFoodEntryByLogin> foodEntries = _foodEntryRepository.GetNbFoodEntries(user.Login);

            if (foodEntries == null)
                return (null, HttpStatusCode.BadRequest, null);

            List<NbFoodEntryByLoginDTOResponse> dtoFoodEntries = foodEntries.Select(foodEntry =>
                new NbFoodEntryByLoginDTOResponse(foodEntry.Login, foodEntry.Name, foodEntry.Total)
            ).ToList();

            return (new GetFoodEntriesCountDTOResponse(dtoFoodEntries), HttpStatusCode.OK, null);
        }
    }
}
