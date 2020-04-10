using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using LevelUpRequests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;

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
            if (Request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

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
