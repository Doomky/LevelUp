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
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            Avatar avatar = await _avatarRepository.GetByUser(user);

            if (avatar != null)
            {
                avatar.Size = DTORequest.NewSize;
                avatar = await _avatarRepository.Update(avatar);
                if (avatar != null)
                    return (new UpdateAvatarDTOResponse(
                        avatar.Id,
                        avatar.Size),
                        HttpStatusCode.OK, null);
            }
            return (null, HttpStatusCode.BadRequest, "Cannot find the avatar for this user");
        }
    }
}
