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
    public class UserInfoRequestHandler : RequestHandler<UserInfoDTORequest, UserInfoDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAvatarRepository _avatarRepository;

        public UserInfoRequestHandler(
            IUserRepository userRepository,
            IAvatarRepository avatarRepository,
            ClaimsPrincipal claims,
            UserInfoDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _avatarRepository = avatarRepository;
        }

        protected override async Task<(UserInfoDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            Avatar avatar = await _avatarRepository.GetByUser(user);

            UserInfo userInfo = new UserInfo(user, avatar);

            return (new UserInfoDTOResponse(
                userInfo.Login,
                userInfo.Lastname,
                userInfo.Lastname,
                userInfo.Gender,
                userInfo.WeightKg,
                userInfo.Email,
                userInfo.LastLoginDate,
                userInfo.GoogleLinked,
                userInfo.Level,
                userInfo.Xp,
                userInfo.XpMax,
                userInfo.Size),
                HttpStatusCode.OK, null);
        }
    }
}
