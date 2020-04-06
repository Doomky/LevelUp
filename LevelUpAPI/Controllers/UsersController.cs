using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LevelUpAPI.Model;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
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

        /// <summary>
        /// Sign in the user. 
        /// </summary>
        /// <response code="200">The user has correctly signed in.</response>
        /// <response code="400">If the request is malformed or the user cannot sign in.</response>
        [HttpPost]
        [Route("signin")]
        public void SignIn()
        {
            SignInRequestHandler SignInHandler = new SignInRequestHandler(_userRepository);
            SignInHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Sign up a new user. 
        /// </summary>
        /// <response code="200">The new user has correctly signed up.</response>
        /// <response code="400">If the request is malformed or the user cannot sign in.</response>
        /// <response code="409">The user already exists in the database.</response>
        [HttpPost]
        [Route("signup")]
        public void SignUp()
        {
            SignUpRequestHandler signUpRequestHandler = new SignUpRequestHandler(_avatarRepository, _userRepository);
            signUpRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Send a mail to a user that forgot his password. 
        /// </summary>
        /// <response code="200">The mail was correctly sent.</response>
        [HttpPost]
        [Route("forgot-password")]
        public void ForgotPassword()
        {
            ForgotPasswordRequestHandler forgotPasswordRequestHandler = new ForgotPasswordRequestHandler(_userRepository, _passwordRecoveryDataRepository, Configuration);
            forgotPasswordRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// The user must enter a new password.
        /// </summary>
        /// <response code="200">The new password is valid.</response>
        [HttpPost]
        [Route("password-recovery")]
        public void PasswordRecovery()
        {
            PasswordRecoveryRequestHandler passwordRecoveryRequestHandler = new PasswordRecoveryRequestHandler(_passwordRecoveryDataRepository, _userRepository);
            passwordRecoveryRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// The user want to change his password.
        /// </summary>
        /// <response code="200">The new password is valid.</response>
        /// <response code="400">The user does not exists or his old password is incorrect.</response>
        /// <response code="401">The user is not connected.</response>
        [HttpPost]
        [Route("change-password")]
        public void ChangePassword()
        {
            ChangePasswordRequestHandler changePasswordRequestHandler = new ChangePasswordRequestHandler(_userRepository);
            changePasswordRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// The user want to access his personal informations.
        /// </summary>
        /// <response code="200">The user is connected and has access to his informations.</response>
        /// <response code="400">The user does not exists.</response>
        /// <response code="401">The user is not connected.</response>
        [HttpGet]
        [Route("user-info")]
        public void GetUserInfo()
        {
            UserInfoRequestHandler userInfoRequestHandler = new UserInfoRequestHandler(_userRepository);
            userInfoRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// The user want to change his personal informations.
        /// </summary>
        /// <response code="200">The user is connected and the new informations are correct.</response>
        /// <response code="400">The user does not exists.</response>
        /// <response code="401">The user is not connected.</response>
        [HttpPost]
        [Route("change-user-info")]
        public void ChangeUserInfo()
        {
            ChangeUserInfoRequestHandler ChangeUserInfoRequestHandler = new ChangeUserInfoRequestHandler(_userRepository);
            ChangeUserInfoRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// The user want to link his LevelUp profile to his Google account.
        /// </summary>
        /// <response code="200">The user is connected and the Google account is correctly linked.</response>
        /// <response code="400">The user does not exists.</response>
        /// <response code="401">The user is not connected.</response>
        [HttpPost]
        [Route("google-id-token/set")]
        public void SetGoogleIdToken()
        {
            SetGoogleIdTokenRequestHandler setGoogleIdTokenRequestHandler = new SetGoogleIdTokenRequestHandler(_userRepository);
            setGoogleIdTokenRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// The user want to remove the link to his Google account.
        /// </summary>
        /// <response code="200">The user is connected and the link is correctly removed.</response>
        /// <response code="400">The user does not exists.</response>
        /// <response code="401">The user is not connected.</response>
        [HttpGet]
        [Route("google-id-token/remove")]
        public void RemoveGoogleIdToken()
        {
            RemoveGoogleIdTokenRequestHandler removeGoogleIdTokenRequestHandler = new RemoveGoogleIdTokenRequestHandler(_userRepository);
            removeGoogleIdTokenRequestHandler.Execute(HttpContext);
        }
    }
}
