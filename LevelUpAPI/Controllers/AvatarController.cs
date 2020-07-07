using System;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
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
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /avatar
        /// 
        /// </remarks>
        /// <returns>The info about the avatar.</returns>
        /// <response code="200">The info about the avatar were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        public async Task<ActionResult<GetAvatarInfoDTOResponse>> Get()
        {
            GetAvatarInfoDTORequest dtoRequest = new GetAvatarInfoDTORequest();
            GetAvatarInfoRequestHandler getAvatarInfoRequestHandler = new GetAvatarInfoRequestHandler(User, dtoRequest, _logger, _userRepository, _avatarRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getAvatarInfoRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Update the avatar of the signed-in user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /avatar/update
        ///     {
        ///        "newSize": 2
        ///     }
        ///
        /// </remarks>
        /// <param name="dtoRequest"></param>
        /// <returns>The id and the new size of the updated avatar</returns>
        /// <response code="200">The avatar was correctly updated.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UpdateAvatarDTOResponse>> Update([FromBody] UpdateAvatarDTORequest dtoRequest)
        {
            UpdateAvatarRequestHandler updateAvatarRequestHandler = new UpdateAvatarRequestHandler(_userRepository, _avatarRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await updateAvatarRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }
    }
}
