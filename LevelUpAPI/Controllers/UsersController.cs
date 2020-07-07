using System;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using LevelUpAPI.Model;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using LevelUpAPI.Helpers;
using LevelUpDTO;

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
        /// Sample request:
        ///
        ///     POST /users/signup
        ///     {
        ///        "login": "usertest",
        ///        "firstname": "user",
        ///        "lastname": "test",
        ///        "gender": 0,
        ///        "emailAddress": "user.test@123.com",
        ///        "passwordHash": "password123"
        ///     }
        /// 
        /// </remarks>
        /// <param name="dtoRequest"></param>
        /// <returns>All the info about the newly created user (id, login, name, weight, email, ...) and its avatar (id, level, size, ...).</returns>
        /// <response code="200">The new user has correctly signed up.</response>
        /// <response code="400">The request is malformed.</response>
        /// <response code="409">The user already exists in the database.</response>
        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<SignUpDTOResponse>> SignUp([FromBody] SignUpDTORequest dtoRequest)
        {
            SignUpRequestHandler signUpRequestHandler = new SignUpRequestHandler(_avatarRepository, _userRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await signUpRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Sign in the user. 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /users/signin
        ///     {
        ///        "login": "usertest",
        ///        "emailAddress": "user.test@123.com",
        ///        "passwordHash": "password123"
        ///     }
        /// 
        /// </remarks>
        /// <param name="dtoRequest"></param>
        /// <returns>The access token of the signed in user.</returns>
        /// <response code="200">The user has correctly signed in.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult<SignInDTOResponse>> SignIn([FromBody] SignInDTORequest dtoRequest)
        {
            SignInRequestHandler signInRequestHandler = new SignInRequestHandler(_userRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await signInRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Sign out the user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /users/signout
        ///     {
        ///        "accessToken": "..."
        ///     }
        /// 
        /// </remarks>
        /// <param name="dtoRequest"></param>
        /// <returns>Nothing.</returns>
        /// <response code="200">The user has correctly signed out.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("signout")]
        public async Task<ActionResult<SignOutDTOResponse>> SignOut([FromBody] SignOutDTORequest dtoRequest)
        {
            SignOutRequestHandler signOutRequestHandler = new SignOutRequestHandler(_userRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await signOutRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Send a mail to a user that forgot his password. 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /users/forgot-password
        ///     {
        ///        "login": "usertest",
        ///        "emailAddress": "user.test@123.com"
        ///     }
        /// 
        /// </remarks>
        /// <param name="dtoRequest"></param>
        /// <returns></returns>
        /// <response code="200">The mail was correctly sent.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
        [HttpPost]
        [Route("forgot-password")]
        public async Task<ActionResult<ForgotPasswordDTOResponse>> ForgotPassword([FromBody] ForgotPasswordDTORequest dtoRequest)
        {
            ForgotPasswordRequestHandler forgotPasswordRequestHandler = new ForgotPasswordRequestHandler(User, dtoRequest, _logger, _userRepository, _passwordRecoveryDataRepository, Configuration);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await forgotPasswordRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// The user must enter a new password.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /users/password-recovery
        ///     {
        ///        "hash": "...",
        ///        "passwordHash": "..."
        ///     }
        /// 
        /// </remarks>
        /// <param name="dtoRequest"></param>
        /// <returns></returns>
        /// <response code="200">The new password is valid.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
        [HttpPost]
        [Route("password-recovery")]
        public async Task<ActionResult<PasswordRecoveryDTOResponse>> PasswordRecovery([FromBody] PasswordRecoveryDTORequest dtoRequest)
        {
            PasswordRecoveryRequestHandler passwordRecoveryRequestHandler = new PasswordRecoveryRequestHandler(_passwordRecoveryDataRepository, _userRepository, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await passwordRecoveryRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// The user want to change his password.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /users/change-password
        ///     {
        ///        "passwordHash": "...",
        ///        "newPasswordHash": "..."
        ///     }
        /// 
        /// </remarks>
        /// <param name="dtoRequest"></param>
        /// <returns></returns>
        /// <response code="200">The new password is valid.</response>
        /// <response code="400">The request is malformed or the user does not exists or his old password is incorrect.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("change-password")]
        public async Task<ActionResult<ChangePasswordDTOResponse>> ChangePassword([FromBody] ChangePasswordDTORequest dtoRequest)
        {
            ChangePasswordRequestHandler changePasswordRequestHandler = new ChangePasswordRequestHandler(User, dtoRequest, _logger, _userRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await changePasswordRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// The user want to access his personal informations.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /users/user-info
        /// 
        /// </remarks>
        /// <returns>All the info about the user (login, name, gender, weight, ...) and its avatar (level, xp, size, ...).</returns>
        /// <response code="200">The user is connected and has access to his informations.</response>
        /// <response code="400">The user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("user-info")]
        public async Task<ActionResult<UserInfoDTOResponse>> GetUserInfo()
        {
            UserInfoDTORequest dtoRequest = new UserInfoDTORequest();
            UserInfoRequestHandler userInfoRequestHandler = new UserInfoRequestHandler(_userRepository, _avatarRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await userInfoRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// The user want to change his personal informations.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /users/change-user-info
        ///     {
        ///         "newFirstname": "bob",
        ///         "newLastname": "test",
        ///         "newEmail": "bob.test@123.com",
        ///         "newWeightKg": 76
        ///     }
        /// 
        /// </remarks>
        /// <param name="dtoRequest"></param>
        /// <returns></returns>
        /// <response code="200">The user is connected and the new informations are correct.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("change-user-info")]
        public async Task<ActionResult<ChangeUserInfoDTOResponse>> ChangeUserInfo([FromBody] ChangeUserInfoDTORequest dtoRequest)
        {
            ChangeUserInfoRequestHandler changeUserInfoRequestHandler = new ChangeUserInfoRequestHandler(User, dtoRequest, _logger, _userRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await changeUserInfoRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// The user want to link his LevelUp profile to his Google account.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /users/link-google-account
        ///     {
        ///         "googleAuthCode": "..."
        ///     }
        /// 
        /// </remarks>
        /// <param name="dtoRequest"></param>
        /// <returns>The Google access token and the access expiration datetime.</returns>
        /// <response code="200">The user is connected and the Google account is correctly linked.</response>
        /// <response code="400">The request is malformed or the user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("link-google-account")]
        public async Task<ActionResult<LinkGoogleAccountDTOResponse>> LinkGoogleAccount([FromBody] LinkGoogleAccountDTORequest dtoRequest)
        {
            LinkGoogleAccountRequestHandler linkGoogleAccountRequestHandler = new LinkGoogleAccountRequestHandler(User, dtoRequest, _logger, _userRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await linkGoogleAccountRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// The user want to get his google access token informations.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /users/google-access-token
        /// 
        /// </remarks>
        /// <returns>The Google access token and the access expiration datetime.</returns>
        /// <response code="200">The user is connected and has access to his access token informations.</response>
        /// <response code="400">The user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("google-access-token")]
        public async Task<ActionResult<AccessTokenInfoDTOResponse>> GetAccessTokenInfo()
        {
            AccessTokenInfoDTORequest dtoRequest = new AccessTokenInfoDTORequest();
            AccessTokenInfoRequestHandler accessTokenInfoRequestHandler = new AccessTokenInfoRequestHandler(_userRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await accessTokenInfoRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// The user want to remove the link to his Google account.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /users/unlink-google-account
        /// 
        /// </remarks>
        /// <returns>The login and the mail of the user as well as the new values for the google (access and refresh) tokens.</returns>
        /// <response code="200">The user is connected and the link is correctly removed.</response>
        /// <response code="400">The user does not exists.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("unlink-google-account")]
        public async Task<ActionResult<UnlinkGoogleAccountDTOResponse>> UnlinkGoogleAccount()
        {
            UnlinkGoogleAccountDTORequest dtoRequest = new UnlinkGoogleAccountDTORequest();
            UnlinkGoogleAccountRequestHandler unlinkGoogleAccountRequestHandler = new UnlinkGoogleAccountRequestHandler(_userRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await unlinkGoogleAccountRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }
    }
}
