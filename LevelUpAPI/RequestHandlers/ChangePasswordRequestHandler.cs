using System;
using Microsoft.AspNetCore.Http;
using LevelUpDTO;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LevelUpAPI.RequestHandlers
{
    public class ChangePasswordRequestHandler : RequestHandler<ChangePasswordDTORequest, ChangePasswordDTOResponse>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";

        private readonly IUserRepository _userRepository;

        public ChangePasswordRequestHandler(ClaimsPrincipal claims, ChangePasswordDTORequest dTORequest, ILogger logger, IUserRepository userRepository) : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
        }

        protected async override Task<(ChangePasswordDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            
            if (user == null)
                return (null, statusCode, err);

            if (user.PasswordHash != DTORequest.PasswordHash)
                return (null, HttpStatusCode.BadRequest, "wrong password");

            user.PasswordHash = DTORequest.NewPasswordHash;
            await _userRepository.Update(user);

            return (new ChangePasswordDTOResponse(), HttpStatusCode.OK, null);
        }
    }
}
