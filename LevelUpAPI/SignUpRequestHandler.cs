using LevelUpAPI.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelUpRequests
{
    public class SignUpRequestHandler : RequestHandler<SignUpRequest>
    {
        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            using (var dbcontext = new levelupContext())
            {
                var query = from users in dbcontext.Users
                       where users.Login == Request.Login || users.Email == Request.EmailAddress
                       select users;
              
                if (query.Any())
                {
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    return;
                }
                else
                {
                    Avatars avatar = new Avatars()
                    {
                        Id = dbcontext.Avatars.Count(),
                        Level = 1,
                        Size = 1,
                        Xp = 0,
                        XpMax = 0,
                    };
                    dbcontext.Avatars.Add(avatar);

                    Users user = new Users()
                    {
                        Id = dbcontext.Users.Count(),
                        Login = Request.Login,
                        Firstname = Request.Firstname,
                        Lastname = Request.Lastname,
                        LastLoginDate = null,
                        AvatarId = avatar.Id
                    };
                    dbcontext.Users.Add(user);

                    context.Response.StatusCode = StatusCodes.Status200OK;
                    return;
                }
            }
        }
    }
}
