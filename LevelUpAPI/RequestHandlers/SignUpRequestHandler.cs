using System;
using Microsoft.AspNetCore.Http;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpDTO;
using LevelUpAPI.Dbo;
using System.Collections.Generic;
using System.Linq;

namespace LevelUpAPI
{
    public class SignUpRequestHandler : RequestHandler<SignUpDTORequest>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";
        public const string endpoint = "clientcredentials";

        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISkinRepository _skinRepository;

        public SignUpRequestHandler(IAvatarRepository avatarRepository, IUserRepository userRepository, ISkinRepository skinRepository)
        {
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
            _skinRepository = skinRepository;
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
                Skin skin = _skinRepository.GetEquipable(1).GetAwaiter().GetResult().FirstOrDefault(skin => skin.Name.Contains("default"));
                Avatar avatar = _avatarRepository.Create(skin.Id).GetAwaiter().GetResult();
                User user = _userRepository.SignUp(Request, avatar.Id).GetAwaiter().GetResult();
                if (user != null)
                    context.Response.StatusCode = StatusCodes.Status200OK;
                return;
            }
        }
    }
}
