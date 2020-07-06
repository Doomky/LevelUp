using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Logging;
using LevelUpDTO;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
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
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            Avatar avatar = _avatarRepository.GetByUser(user).GetAwaiter().GetResult();

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
