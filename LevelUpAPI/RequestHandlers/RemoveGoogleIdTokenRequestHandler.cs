using System;
using Microsoft.AspNetCore.Http;
using LevelUpRequests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class RemoveGoogleIdTokenRequestHandler : RequestHandler<RemoveGoogleIdTokenRequest>
    {
        private IUserRepository _userRepository;

        public RemoveGoogleIdTokenRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            user.GoogleId = null;
            _userRepository.Update(user);
            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
