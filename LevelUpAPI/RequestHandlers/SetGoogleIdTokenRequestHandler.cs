using System;
using Microsoft.AspNetCore.Http;
using LevelUpRequests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class SetGoogleIdTokenRequestHandler : RequestHandler<SetGoogleIdTokenRequest>
    {
        private IUserRepository _userRepository;

        public SetGoogleIdTokenRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            user.GoogleId = Request.GoogleIdToken;
            _userRepository.Update(user);
            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
