using System;
using Microsoft.AspNetCore.Http;
using LevelUpDTO;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class ChangeUserInfoRequestHandler : RequestHandler<ChangeUserInfoDTORequest, ChangeUserInfoDTOResponse>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserInfoRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<ChangeUserInfoDTOResponse> ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(DTORequest, context, _userRepository);
            if (!isOk || user == null)
                return null;

            if (DTORequest.NewEmail != user.Email && !string.IsNullOrWhiteSpace(DTORequest.NewEmail))
            {
                user.Email = DTORequest.NewEmail;
            }
            if (DTORequest.NewFirstname != user.Firstname && !string.IsNullOrWhiteSpace(DTORequest.NewFirstname))
            {
                user.Firstname = DTORequest.NewFirstname;
            }
            if (DTORequest.NewLastname != user.Lastname && !string.IsNullOrWhiteSpace(DTORequest.NewLastname))
            {
                user.Lastname = DTORequest.NewLastname;
            }
            if (DTORequest.NewWeightKg != user.WeightKg && DTORequest.NewWeightKg != null)
            {
                user.WeightKg = DTORequest.NewWeightKg.Value;
            }

            _userRepository.Update(user).GetAwaiter().GetResult();

            context.Response.StatusCode = StatusCodes.Status200OK;
            return new ChangeUserInfoDTOResponse();
        }
    }
}
