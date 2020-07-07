using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using LevelUpAPI.Model;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using LevelUpDTO;
using System.Net;
using LevelUpAPI.Helpers;

namespace LevelUpAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvatarController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly levelupContext _context;
        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;

        public AvatarController(ILogger<UsersController> logger, levelupContext context, IAvatarRepository avatarRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _context = context;
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all the info about the avatar of the signed-in user.
        /// </summary>
        /// <response code="200">The info about the avatar were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        public async Task<ActionResult<GetAvatarInfoDTOResponse>> Get()
        {
            GetAvatarInfoDTORequest dtoRequest = new GetAvatarInfoDTORequest();
            GetAvatarInfoRequestHandler getAvatarInfoRequestHandler = new GetAvatarInfoRequestHandler(User, dtoRequest, _logger, _userRepository, _avatarRepository);
            (GetAvatarInfoDTOResponse dtoResponse, HttpStatusCode statusCode, string err) = await getAvatarInfoRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Update the avatar of the signed-in user.
        /// </summary>
        /// <remarks>
        /// The body of the request must contains this field:
        /// 
        ///     {
        ///         "NewSize"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The avatar was correctly updated.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UpdateAvatarDTOResponse>> Update([FromBody] UpdateAvatarDTORequest dtoRequest)
        {
            UpdateAvatarRequestHandler updateAvatarRequestHandler = new UpdateAvatarRequestHandler(_userRepository, _avatarRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await updateAvatarRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }
    }
}
