using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<Users, User>
    {

        public Task<Dbo.User> GetUserByClaims(ClaimsPrincipal claimsPrincipal);

        public Task<Dbo.User> GetUserById(int id);

        public Task<Dbo.User> GetUserByLogin(string login);

        public Task<bool> CanSignUp(SignUpRequest signUpRequest);
        public Task<Dbo.User> SignUp(SignUpRequest signUpRequest, int avatarId);
        public Task<bool> CanSignIn(SignInRequest signInRequest);
    }
}
