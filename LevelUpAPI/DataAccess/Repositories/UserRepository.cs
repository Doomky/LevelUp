using IdentityServer4.Models;
using LevelUpAPI.Model;
using LevelUpRequests;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class UserRepository : Repository<Model.Users, Dbo.User>
    {
        public UserRepository(levelupContext context, ILogger logger) : base(context, context.Users, logger)
        {

        }

        public async Task<Dbo.User> GetUserById(int id)
        {
            var arr = await base.Get(id);
            if (arr.Any())
            {
                return arr.First();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CanSignUp(SignUpRequest signUpRequest)
        {
            var arr = await base.Get();
            var query = from user in arr
                        where user.Login == signUpRequest.Login || user.Email == signUpRequest.EmailAddress
                        select user;

            return query.Any();
        }

        public async Task<Dbo.User> SignUp(SignUpRequest signUpRequest, int avatarId)
        {
            Dbo.User user = new Dbo.User()
            {
                Login = signUpRequest.Login,
                Firstname = signUpRequest.Firstname,
                Lastname = signUpRequest.Lastname,
                Email = signUpRequest.EmailAddress,
                PasswordHash = signUpRequest.PasswordHash.Sha256(),
                LastLoginDate = null,
                AvatarId = avatarId
            };
            return user = await Insert(user);
        }
    }
}
