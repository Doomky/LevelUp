using System;
using Microsoft.AspNetCore.Http;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpRequests;

namespace LevelUpAPI
{
    public class SignUpRequestHandler : RequestHandler<SignUpRequest>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";
        public const string endpoint = "clientcredentials";

        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;

        public SignUpRequestHandler(IAvatarRepository avatarRepository, IUserRepository userRepository)
        {
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null || string.IsNullOrWhiteSpace(Request.Login)
                || string.IsNullOrWhiteSpace(Request.Firstname)
                || string.IsNullOrWhiteSpace(Request.Lastname)
                || string.IsNullOrWhiteSpace(Request.EmailAddress)
                || string.IsNullOrWhiteSpace(Request.PasswordHash))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            if (!_userRepository.CanSignUp(Request).GetAwaiter().GetResult())
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                return;
            }
            else
            {
                Dbo.Avatar avatar = _avatarRepository.Create().GetAwaiter().GetResult();
                Dbo.User user = _userRepository.SignUp(Request, avatar.Id).GetAwaiter().GetResult();
                if (user != null)
                    context.Response.StatusCode = StatusCodes.Status200OK;
                return;
            }
        }
    }
}
