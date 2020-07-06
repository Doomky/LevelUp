using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using static LevelUpDTO.GetPAEntriesDTOResponse;

namespace LevelUpAPI.RequestHandlers
{
    public class GetTotalPAEntriesRequestHandler : RequestHandler<GetPAEntriesDTORequest,GetPAEntriesDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public GetTotalPAEntriesRequestHandler(GetPAEntriesDTORequest dTORequest, ILogger logger, IUserRepository userRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository) : base(dTORequest, logger)
        {
            _userRepository = userRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
        }

        protected override async Task<(GetPAEntriesDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string errMsg) = CheckClaimsForUser(DTORequest, null, _userRepository);
            if (user == null)
                return (null, statusCode, errMsg);

            IEnumerable<NbPhysicalActivityEntryByLogin> totalPAEntries =  _physicalActivitiesEntryRepository.GetTotalByLogin(user.Login).GetAwaiter().GetResult();
            List<PAEntryDTOResponse> pAEntries = totalPAEntries.Select(entry => new PAEntryDTOResponse(entry.Login, entry.Login, entry.Total)).ToList();

            return (new GetPAEntriesDTOResponse(pAEntries), HttpStatusCode.OK, null);
        }
    }
}
