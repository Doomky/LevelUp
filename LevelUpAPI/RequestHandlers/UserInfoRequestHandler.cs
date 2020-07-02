using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using LevelUpDTO;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class UserInfoRequestHandler : RequestHandler<UserInfoDTORequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAvatarRepository _avatarRepository;

        public UserInfoRequestHandler(IUserRepository userRepository, IAvatarRepository avatarRepository)
        {
            _userRepository = userRepository;
            _avatarRepository = avatarRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            Avatar avatar = _avatarRepository.GetByUser(user).GetAwaiter().GetResult();

            UserInfo userInfo = new UserInfo(user, avatar);

            string userInfoJson = JsonSerializer.Serialize(userInfo);

            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(userInfoJson).GetAwaiter().GetResult();
        }
    }
}
