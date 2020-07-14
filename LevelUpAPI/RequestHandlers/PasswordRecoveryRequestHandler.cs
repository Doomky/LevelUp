using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class PasswordRecoveryRequestHandler : RequestHandler<PasswordRecoveryDTORequest, PasswordRecoveryDTOResponse>
    {
        private readonly IPasswordRecoveryDataRepository _passwordRecoveryDataRepository;
        private readonly IUserRepository _userRepository;

        public PasswordRecoveryRequestHandler(IPasswordRecoveryDataRepository passwordRecoveryDataRepository, IUserRepository userRepository, ClaimsPrincipal claims, PasswordRecoveryDTORequest dTORequest, ILogger logger) : base(claims, dTORequest, logger)
        {
            _passwordRecoveryDataRepository = passwordRecoveryDataRepository;
            _userRepository = userRepository;
        }

        protected async override Task<(PasswordRecoveryDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            if (DTORequest == null)
                return (null, HttpStatusCode.BadRequest, null);

            PasswordRecoveryData passwordRecoveryData = await _passwordRecoveryDataRepository.GetByHash(DTORequest.Hash);

            if (passwordRecoveryData == null)
                return (null, HttpStatusCode.BadRequest, null);

            User user = await _userRepository.GetUserById(passwordRecoveryData.UserId);
            if (user != null)
            {
                user.PasswordHash = DTORequest.PasswordHash;
                await _userRepository.Update(user);
            }
            await _passwordRecoveryDataRepository.Delete(passwordRecoveryData.Id);

            return (new PasswordRecoveryDTOResponse(), HttpStatusCode.OK, null);
        }
    }
}
