using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

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
            ClaimsPrincipal claims = context.User;
            if (claims == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsync("no claims").GetAwaiter().GetResult();
                return;
            }

            Dbo.User user = _userRepository.GetUserByClaims(claims).GetAwaiter().GetResult();

            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("no user for this client_id").GetAwaiter().GetResult();
                return;
            }

            Dbo.UserInfo userInfo = new Dbo.UserInfo(user);

            string userInfoJson = JsonSerializer.Serialize<Dbo.UserInfo>(userInfo);

            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(userInfoJson).GetAwaiter().GetResult();
        }
    }
}
