using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using LevelUpAPI.Model;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;


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
        /// Sign up a new user. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "Login"
        ///         "Firstname"
        ///         "Lastname"
        ///         "Gender"
        ///         "EmailAddress"
        ///         "PasswordHash"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new user has correctly signed up.</response>
        /// <response code="400">The request is malformed.</response>
        /// <response code="409">The user already exists in the database.</response>
        [HttpPost]
        [Route("signup")]
        public void SignUp()
        {
            SignUpRequestHandler signUpRequestHandler = new SignUpRequestHandler(_avatarRepository, _userRepository);
            signUpRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Sign in the user. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "Login" or "EmailAddress" (at least 1)
        ///         "PasswordHash"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The user has correctly signed in.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
        [HttpPost]
        [Route("signin")]
        public void SignIn()
        {
            SignInRequestHandler SignInHandler = new SignInRequestHandler(_userRepository);
            SignInHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Sign out the user.
        /// </summary>
        /// <remarks>
        /// The body of the request must contains this field:
        /// 
        ///     {
        ///         "AccessToken"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The user has correctly signed out.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("signout")]
        public void SignOut()
        {
            SignOutRequestHandler SignOutHandler = new SignOutRequestHandler(_userRepository);
            SignOutHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Send a mail to a user that forgot his password. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "Login" or "EmailAddress" (at least 1)
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The mail was correctly sent.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
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
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "Hash"
        ///         "PasswordHash"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new password is valid.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
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
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "PasswordHash"
        ///         "NewPasswordHash"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new password is valid.</response>
        /// <response code="400">The request is malformed or the user does not exists or his old password is incorrect.</response>
        /// <response code="401">The user is not signed in.</response>
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
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("user-info")]
        public void GetUserInfo()
        {
            UserInfoRequestHandler userInfoRequestHandler = new UserInfoRequestHandler(_userRepository, _avatarRepository);
            userInfoRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// The user want to change his personal informations.
        /// </summary>
        /// <remarks>
        /// The body of the request can contains those fields:
        /// 
        ///     {
        ///         "NewFirstname"
        ///         "NewLastname"
        ///         "NewEmail"
        ///         "NewWeightKg"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The user is connected and the new informations are correct.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
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
        /// <remarks>
        /// The body of the request must contains this field:
        /// 
        ///     {
        ///         "GoogleAuthCode"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The user is connected and the Google account is correctly linked.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("link-google-account")]
        public void LinkGoogleAccount()
        {
            LinkGoogleAccountRequestHandler LinGoogleAccountRequestHandler = new LinkGoogleAccountRequestHandler(_userRepository);
            LinGoogleAccountRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// The user want to get his google access token informations.
        /// </summary>
        /// <response code="200">The user is connected and has access to his access token informations.</response>
        /// <response code="400">The user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("google-access-token")]
        public void GetAccessTokenInfo()
        {
            AccessTokenInfoRequestHandler accessTokenInfoRequestHandler = new AccessTokenInfoRequestHandler(_userRepository);
            accessTokenInfoRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// The user want to remove the link to his Google account.
        /// </summary>
        /// <response code="200">The user is connected and the link is correctly removed.</response>
        /// <response code="400">The user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("unlink-google-account")]
        public void UnlinkGoogleAccount()
        {
            UnlinkGoogleAccountRequestHandler UnlinkGoogleAccountRequestHandler = new UnlinkGoogleAccountRequestHandler(_userRepository);
            UnlinkGoogleAccountRequestHandler.Execute(HttpContext);
        }
    }
}
