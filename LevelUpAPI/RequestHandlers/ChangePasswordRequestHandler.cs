using System;
using Microsoft.AspNetCore.Http;
using LevelUpDTO;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class ChangePasswordRequestHandler : RequestHandler<ChangePasswordDTORequest, ChangePasswordDTOResponse>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";

        private readonly IUserRepository _userRepository;

        public ChangePasswordRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<ChangePasswordDTOResponse> ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(DTORequest, context, _userRepository);
            if (!isOk || user == null)
                return null;

            if (user.PasswordHash != DTORequest.PasswordHash)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("wrong password").GetAwaiter().GetResult();
                return null;
            }

            user.PasswordHash = DTORequest.NewPasswordHash;
            _userRepository.Update(user).GetAwaiter().GetResult();

            context.Response.StatusCode = StatusCodes.Status200OK;
            return new ChangePasswordDTOResponse();
        }
    }
}
