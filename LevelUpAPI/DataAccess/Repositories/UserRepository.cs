using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using LevelUpRequests;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class UserRepository : Repository<Users, User>, IUserRepository
    {
        public UserRepository(levelupContext context, ILogger<UserRepository> logger, IMapper mapper) : base(context, context.Users, logger, mapper)
        {

        }

        public async Task<User> GetUserById(int id)
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

        public async Task<User> SignUp(SignUpRequest signUpRequest, int avatarId)
        {
            User user = new User()
            {
                Login = signUpRequest.Login,
                Firstname = signUpRequest.Firstname,
                Lastname = signUpRequest.Lastname,
                Email = signUpRequest.EmailAddress,
                PasswordHash = signUpRequest.PasswordHash,
                LastLoginDate = null,
                AvatarId = avatarId
            };
            return await Insert(user);
        }

        public async Task<bool> CanSignIn(SignInRequest signInRequest)
        {
            var arr = await base.Get();
            var query = from users in arr
                        where users.Login == signInRequest.Login || users.Email == signInRequest.EmailAddress
                        select users;
            return query.Any();
        }

        public async Task<User> GetUserByLoginOrEmail(string login = null, string email = null)
        {
            var arr = await base.Get();
            var query = from users in arr
                        where (login != null && users.Login == login) || (email != null && users.Email == email)
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
                    return await GetUserByLoginOrEmail(claim.Value);
            return null;
        }
    }
}
