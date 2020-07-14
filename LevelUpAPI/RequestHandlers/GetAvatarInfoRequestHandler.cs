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
    public class GetAvatarInfoRequestHandler : RequestHandler<GetAvatarInfoDTORequest, GetAvatarInfoDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAvatarRepository _avatarRepository;

        public GetAvatarInfoRequestHandler(ClaimsPrincipal claims, GetAvatarInfoDTORequest dtoRequest, ILogger logger, IUserRepository userRepository, IAvatarRepository avatarRepository) : base(claims, dtoRequest, logger)
        {
            _userRepository = userRepository;
            _avatarRepository = avatarRepository;
        }

        protected async override Task<(GetAvatarInfoDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);

            if (user == null)
                return (null, statusCode, err);

            Avatar avatar = await _avatarRepository.GetByUser(user);

            if (avatar == null)
                return (null, HttpStatusCode.BadRequest, null);

            GetAvatarInfoDTOResponse dtoResponse = new GetAvatarInfoDTOResponse(
                avatar.Id,
                avatar.Level,
                avatar.Xp,
                avatar.XpMax,
                avatar.Size
            );

            return (dtoResponse, HttpStatusCode.OK, null);
        }
    }
}
