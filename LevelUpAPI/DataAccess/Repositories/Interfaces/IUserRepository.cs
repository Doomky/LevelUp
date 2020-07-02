using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using LevelUpDTO;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<Users, User>
    {

        public Task<User> GetUserByClaims(ClaimsPrincipal claimsPrincipal);

        public Task<User> GetUserById(int id);

        public Task<User> GetUserByLoginOrEmail(string login = null, string email = null);

        public Task<bool> CanSignUp(SignUpDTORequest signUpRequest);
        public Task<User> SignUp(SignUpDTORequest signUpRequest, int avatarId);
        public Task<bool> CanSignIn(SignInDTORequest signInRequest);
    }
}
