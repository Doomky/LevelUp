using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Net;
using static LevelUpAPI.Helpers.ClaimsHelpers;

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
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            
            if (user == null)
                return (null, statusCode, err);

            if (user.PasswordHash != DTORequest.PasswordHash)
                return (null, HttpStatusCode.BadRequest, "Wrong password");

            user.PasswordHash = DTORequest.NewPasswordHash;
            await _userRepository.Update(user);

            return (new ChangePasswordDTOResponse(), HttpStatusCode.OK, null);
        }
    }
}
