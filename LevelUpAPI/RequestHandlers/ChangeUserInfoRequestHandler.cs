using System;
using Microsoft.AspNetCore.Http;
using LevelUpRequests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class ChangeUserInfoRequestHandler : RequestHandler<ChangeUserInfoRequest>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserInfoRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            if (Request.NewEmail != user.Email && !string.IsNullOrWhiteSpace(Request.NewEmail))
            {
                user.Email = Request.NewEmail;
            }
            if (Request.NewFirstname != user.Firstname && !string.IsNullOrWhiteSpace(Request.NewFirstname))
            {
                user.Firstname = Request.NewFirstname;
            }
            if (Request.NewLastname != user.Lastname && !string.IsNullOrWhiteSpace(Request.NewLastname))
            {
                user.Lastname = Request.NewLastname;
            }
            if (Request.NewGoogleId != user.GoogleId && !string.IsNullOrWhiteSpace(Request.NewGoogleId))
            {
                user.GoogleId = Request.NewGoogleId;
            }
            _userRepository.Update(user).GetAwaiter().GetResult();

            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
