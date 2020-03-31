using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class PasswordRecoveryRequestHandler : RequestHandler<PasswordRecoveryRequest>
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
        }
    }
}
