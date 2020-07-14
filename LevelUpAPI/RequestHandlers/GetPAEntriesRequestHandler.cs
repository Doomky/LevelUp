using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using static LevelUpDTO.GetPAEntriesDTOResponse;

namespace LevelUpAPI.RequestHandlers
{
    public class GetPAEntriesRequestHandler : RequestHandler<GetPAEntriesDTORequest, GetPAEntriesDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public GetPAEntriesRequestHandler(ClaimsPrincipal claims, GetPAEntriesDTORequest dtoRequest, ILogger logger, IUserRepository userRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository) : base(claims, dtoRequest, logger)
        {
            _userRepository = userRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
        }

        protected async override Task<(GetPAEntriesDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string errMsg) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, errMsg);

            IEnumerable<PhysicalActivityEntry> PAEntries = await _physicalActivitiesEntryRepository.GetByLogin(user.Login);

            if (PAEntries == null)
                return (null, HttpStatusCode.BadRequest, errMsg);

            List<PAEntryDTOResponse> paEntriesDTO = PAEntries.Select(paentry =>
                new PAEntryDTOResponse(paentry.Id, paentry.UserId, paentry.PhysicalActivitiesId, paentry.DatetimeStart, paentry.DatetimeEnd)
            ).ToList();

            GetPAEntriesDTOResponse dtoResponse = new GetPAEntriesDTOResponse(paEntriesDTO);

            return (dtoResponse, HttpStatusCode.OK, null);
        }
    }
}
