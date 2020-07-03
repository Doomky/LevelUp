using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class AccessTokenInfoRequestHandler : RequestHandler<AccessTokenInfoDTORequest, AccessTokenInfoDTOResponse>
    {
        private IUserRepository _userRepository;

        public AccessTokenInfoRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<AccessTokenInfoDTOResponse> ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(DTORequest, context, _userRepository);
            if (!isOk || user == null)
                return null;

            AccessTokenInfo accessTokenInfo = new AccessTokenInfo(user);

            string accessTokenInfoJson = JsonSerializer.Serialize(accessTokenInfo);

            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(accessTokenInfoJson).GetAwaiter().GetResult();
            return JsonSerializer.Deserialize<AccessTokenInfoDTOResponse>(accessTokenInfoJson);
        }
    }
}
