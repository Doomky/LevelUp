using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class RemovePAEntryRequestHandler : RequestHandler<RemovePAEntryDTORequest, RemovePAEntryDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public RemovePAEntryRequestHandler(
            IUserRepository userRepository,
            IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository,
            ClaimsPrincipal claims,
            RemovePAEntryDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
        }

        protected override async Task<(RemovePAEntryDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            PhysicalActivityEntry PAEntry = _physicalActivitiesEntryRepository.Get(DTORequest.Id).GetAwaiter().GetResult().FirstOrDefault();
            if (PAEntry == null)
                return (null, HttpStatusCode.BadRequest, "Could not find the given physical activity entry, please check body data sanity");

            if (!_physicalActivitiesEntryRepository.Delete(DTORequest.Id).GetAwaiter().GetResult())
                return (null, HttpStatusCode.BadRequest, "Could not remove the given physical activity entry");
            return (new RemovePAEntryDTOResponse(DTORequest.Id), HttpStatusCode.OK, null);
        }
    }
}
