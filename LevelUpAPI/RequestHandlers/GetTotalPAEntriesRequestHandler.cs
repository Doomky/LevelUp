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
using static LevelUpDTO.GetTotalPAEntriesDTOResponse;

namespace LevelUpAPI.RequestHandlers
{
    public class GetTotalPAEntriesRequestHandler : RequestHandler<GetTotalPAEntriesDTORequest, GetTotalPAEntriesDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public GetTotalPAEntriesRequestHandler(ClaimsPrincipal claims, GetTotalPAEntriesDTORequest dTORequest, ILogger logger, IUserRepository userRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository) : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
        }

        protected override async Task<(GetTotalPAEntriesDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string errMsg) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, errMsg);

            IEnumerable<NbPhysicalActivityEntryByLogin> totalPAEntries =  await _physicalActivitiesEntryRepository.GetTotalByLogin(user.Login);

            List<PAEntryByLoginDTOResponse> pAEntries = totalPAEntries.Select(paEntry =>
                new PAEntryByLoginDTOResponse(paEntry.Login, paEntry.Name, paEntry.Total)
            ).ToList();

            GetTotalPAEntriesDTOResponse dtoResponse = new GetTotalPAEntriesDTOResponse(pAEntries);

            return (dtoResponse, HttpStatusCode.OK, null);
        }
    }
}
