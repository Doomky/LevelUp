using IdentityServer4.Models;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using LevelUpRequests;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class UserRepository : Repository<Model.Users, Dbo.User>, IUserRepository
    {
        public UserRepository(levelupContext context, ILogger<UserRepository> logger) : base(context, context.Users, logger)
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

            return !query.Any();
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

        public async Task<bool> CanSignIn(SignInRequest signInRequest)
        {
            var arr = await base.Get();
            var query = from users in arr
                        where users.Login == signInRequest.Login || users.Email == signInRequest.EmailAddress
                        select users;
            return query.Any();
        }

        public async Task<User> GetUserByLogin(string login)
        {
            var arr = await base.Get();
            var query = from users in arr
                        where users.Login == login
                        select users;
            if (query.Any())
            {
                return query.First();
            }
            return null;
        }

        public async Task<User> GetUserByClaims(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                return null;
            foreach (var claim in claimsPrincipal.Claims)
                if (claim.Type == "client_id")
                    return await GetUserByLogin(claim.Value);
            return null;
        }
    }
}
