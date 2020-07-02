using System;
using Microsoft.AspNetCore.Http;
using LevelUpDTO;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;

namespace LevelUpAPI.RequestHandlers
{
    public class PasswordRecoveryRequestHandler : RequestHandler<PasswordRecoveryDTORequest>
    {
        private readonly IPasswordRecoveryDataRepository _passwordRecoveryDataRepository;
        private readonly IUserRepository _userRepository;

        public PasswordRecoveryRequestHandler(IPasswordRecoveryDataRepository passwordRecoveryDataRepository, IUserRepository userRepository)
        {
            _passwordRecoveryDataRepository = passwordRecoveryDataRepository;
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null || string.IsNullOrWhiteSpace(Request.Hash)
                || string.IsNullOrWhiteSpace(Request.PasswordHash))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            PasswordRecoveryData passwordRecoveryData = _passwordRecoveryDataRepository.GetByHash(Request.Hash).GetAwaiter().GetResult();
            if (passwordRecoveryData != null)
            {
                User user = _userRepository.GetUserById(passwordRecoveryData.UserId).GetAwaiter().GetResult();
                if (user != null)
                {
                    user.PasswordHash = Request.PasswordHash;
                    _userRepository.Update(user);
                }
                _passwordRecoveryDataRepository.Delete(passwordRecoveryData.Id).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
