using System;
using Microsoft.AspNetCore.Http;
using LevelUpDTO;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Net;

namespace LevelUpAPI.RequestHandlers
{
    public class ChangeUserInfoRequestHandler : RequestHandler<ChangeUserInfoDTORequest, ChangeUserInfoDTOResponse>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserInfoRequestHandler(ClaimsPrincipal claims, ChangeUserInfoDTORequest dTORequest, ILogger logger, IUserRepository userRepository) : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
        }


        protected async override Task<(ChangeUserInfoDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            if (!string.IsNullOrWhiteSpace(DTORequest.NewEmail))
                user.Email = DTORequest.NewEmail;
            if (!string.IsNullOrWhiteSpace(DTORequest.NewFirstname))
                user.Firstname = DTORequest.NewFirstname;
            if (!string.IsNullOrWhiteSpace(DTORequest.NewLastname))
                user.Lastname = DTORequest.NewLastname;
            if (DTORequest.NewWeightKg.HasValue)
                user.WeightKg = DTORequest.NewWeightKg.Value;

            await _userRepository.Update(user);

            return (new ChangeUserInfoDTOResponse(), HttpStatusCode.OK, null);
        }
    }
}
