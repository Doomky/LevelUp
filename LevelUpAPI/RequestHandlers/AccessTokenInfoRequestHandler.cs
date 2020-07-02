using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class AccessTokenInfoRequestHandler : RequestHandler<AccessTokenInfoDTORequest>
    {
        private IUserRepository _userRepository;

        public AccessTokenInfoRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            AccessTokenInfo accessTokenInfo = new AccessTokenInfo(user);

            string accessTokenInfoJson = JsonSerializer.Serialize(accessTokenInfo);

            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(accessTokenInfoJson).GetAwaiter().GetResult();
        }
    }
}
