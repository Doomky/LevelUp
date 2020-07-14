using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LevelUpAPI
{
    public class SignUpRequestHandler : RequestHandler<SignUpDTORequest, SignUpDTOResponse>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";
        public const string endpoint = "clientcredentials";

        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;

        public SignUpRequestHandler(
            IAvatarRepository avatarRepository,
            IUserRepository userRepository,
            ClaimsPrincipal claims,
            SignUpDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
        }

        protected override async Task<(SignUpDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            if (DTORequest == null)
                return (null, HttpStatusCode.BadRequest, "Request malformed, please check body data sanity");

            if (!await _userRepository.CanSignUp(DTORequest))
                return (null, HttpStatusCode.Conflict, "User already exists, please use another email address or login");
            else
            {
                Dbo.Avatar avatar = await _avatarRepository.Create();
                Dbo.User user = await _userRepository.SignUp(DTORequest, avatar.Id);
                if (user != null)
                    return (new SignUpDTOResponse(
                        user.Id,
                        user.Login,
                        user.Firstname,
                        user.Lastname,
                        user.Gender,
                        user.WeightKg,
                        user.Email,
                        avatar.Id,
                        avatar.Level,
                        avatar.Xp,
                        avatar.XpMax,
                        avatar.Size,
                        user.CreationDate),
                        HttpStatusCode.OK, null);
            }
            return (null, HttpStatusCode.BadRequest, "Could not register the user, please contact us");
        }
    }
}
