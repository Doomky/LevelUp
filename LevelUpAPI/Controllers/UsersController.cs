using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LevelUpAPI.Helpers;
using LevelUpAPI.Model;
using LevelUpAPI.Dbo;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace LevelUpAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly levelupContext _context;
        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRecoveryDataRepository _passwordRecoveryDataRepository;
        private readonly IConfiguration Configuration;

        public UsersController(ILogger<UsersController> logger, levelupContext context, IAvatarRepository avatarRepository, IUserRepository userRepository, IPasswordRecoveryDataRepository passwordRecoveryDataRepository, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
            _passwordRecoveryDataRepository = passwordRecoveryDataRepository;
            Configuration = configuration;
        }

        [HttpPost]
        [Route("signin")]
        public void SignIn()
        {
            SignInRequestHandler SignInHandler = new SignInRequestHandler(_userRepository);
            SignInHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("signup")]
        public void SignUp()
        {
            SignUpRequestHandler signUpRequestHandler = new SignUpRequestHandler(_avatarRepository, _userRepository);
            signUpRequestHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("forgot-password")]
        public void ForgotPassword()
        {
            ForgotPasswordRequestHandler forgotPasswordRequestHandler = new ForgotPasswordRequestHandler(_userRepository, _passwordRecoveryDataRepository, Configuration);
            forgotPasswordRequestHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("password-recovery")]
        public void PasswordRecovery()
        {
            PasswordRecoveryRequestHandler passwordRecoveryRequestHandler = new PasswordRecoveryRequestHandler(_passwordRecoveryDataRepository, _userRepository);
            passwordRecoveryRequestHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("change-password")]
        public void ChangePassword()
        {
            ChangePasswordRequestHandler changePasswordRequestHandler = new ChangePasswordRequestHandler(_userRepository);
            changePasswordRequestHandler.Execute(HttpContext);
        }

        [HttpGet]
        [Route("user-info")]
        public void GetUserInfo()
        {
            UserInfoRequestHandler userInfoRequestHandler = new UserInfoRequestHandler(_userRepository);
            userInfoRequestHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("change-user-info")]
        public void ChangeUserInfo()
        {
            ChangeUserInfoRequestHandler ChangeUserInfoRequestHandler = new ChangeUserInfoRequestHandler(_userRepository);
            ChangeUserInfoRequestHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("google-id-token/set")]
        public void SetGoogleIdToken()
        {
            SetGoogleIdTokenRequestHandler setGoogleIdTokenRequestHandler = new SetGoogleIdTokenRequestHandler(_userRepository);
            setGoogleIdTokenRequestHandler.Execute(HttpContext);
        }

        [HttpGet]
        [Route("google-id-token/remove")]
        public void RemoveGoogleIdToken()
        {
            RemoveGoogleIdTokenRequestHandler removeGoogleIdTokenRequestHandler = new RemoveGoogleIdTokenRequestHandler(_userRepository);
            removeGoogleIdTokenRequestHandler.Execute(HttpContext);
        }
    }
}
