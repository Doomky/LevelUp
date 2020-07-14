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
    public class RemoveQuestRequestHandler : RequestHandler<RemoveQuestDTORequest, RemoveQuestDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;

        public RemoveQuestRequestHandler(
            IUserRepository userRepository,
            IQuestRepository questRepository,
            ClaimsPrincipal claims,
            RemoveQuestDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
        }

        protected override async Task<(RemoveQuestDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            if (!await _questRepository.Delete(DTORequest.QuestId))
                return (null, HttpStatusCode.BadRequest, "Could not remove the given quest");

            return (new RemoveQuestDTOResponse(DTORequest.QuestId), HttpStatusCode.OK, null);
        }
    }
}
