using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class UpdateAvatarRequestHandler : RequestHandler<UpdateAvatarDTORequest, UpdateAvatarDTOResponse>
    {
        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;

        public UpdateAvatarRequestHandler(
            IUserRepository userRepository,
            IAvatarRepository avatarRepository,
            ClaimsPrincipal claims,
            UpdateAvatarDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
        }

        protected override async Task<(UpdateAvatarDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            Avatar avatar = _avatarRepository.GetByUser(user).GetAwaiter().GetResult();

            if (avatar != null)
            {
                avatar.Size = DTORequest.NewSize;
                avatar = _avatarRepository.Update(avatar).GetAwaiter().GetResult();
                if (avatar != null)
                    return (new UpdateAvatarDTOResponse(
                        avatar.Id,
                        avatar.Level,
                        avatar.Xp,
                        avatar.XpMax,
                        avatar.Size),
                        HttpStatusCode.OK, null);
            }
            return (null, HttpStatusCode.BadRequest, "Cannot find the avatar for this user");
        }
    }
}
