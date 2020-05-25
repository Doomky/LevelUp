using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using LevelUpRequests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class UserInfoRequestHandler : RequestHandler<UserInfoRequest>
    {
        private readonly IUserRepository _userRepository;

        public UserInfoRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            UserInfo userInfo = new UserInfo(user);

            string userInfoJson = JsonSerializer.Serialize(userInfo);

            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(userInfoJson).GetAwaiter().GetResult();
        }
    }
}
