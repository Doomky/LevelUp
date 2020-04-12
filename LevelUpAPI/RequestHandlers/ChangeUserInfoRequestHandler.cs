using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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

            if (Request.NewEmail != user.Email && !string.IsNullOrEmpty(Request.NewEmail))
            {
                user.Email = Request.NewEmail;
            }
            if (Request.NewFirstname != user.Firstname && !string.IsNullOrEmpty(Request.NewFirstname))
            {
                user.Firstname = Request.NewFirstname;
            }
            if (Request.NewLastname != user.Lastname && !string.IsNullOrEmpty(Request.NewLastname))
            {
                user.Lastname = Request.NewLastname;
            }

            _userRepository.Update(user).GetAwaiter().GetResult();

            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
