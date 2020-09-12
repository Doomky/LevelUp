using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using LevelUpAPI.Model;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;


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
        private readonly ISkinRepository _skinRepository;

        public AvatarController(ILogger<UsersController> logger, levelupContext context, IAvatarRepository avatarRepository, IUserRepository userRepository, ISkinRepository skinRepository)
        {
            _logger = logger;
            _context = context;
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
            _skinRepository = skinRepository;
        }

        /// <summary>
        /// Get all the info about the avatar of the signed-in user.
        /// </summary>
        /// <response code="200">The info about the avatar were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        public void Get()
        {
            GetAvatarInfoRequestHandler getAvatarInfoRequestHandler = new GetAvatarInfoRequestHandler(_userRepository, _avatarRepository);
            getAvatarInfoRequestHandler.Execute(HttpContext);
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
        public void Update()
        {
            UpdateAvatarRequestHandler updateAvatarRequestHandler = new UpdateAvatarRequestHandler(_userRepository, _avatarRepository);
            updateAvatarRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Get the name of the current skin of the avatar of the signed-in user.
        /// </summary>
        /// <response code="200">The name of the current skin was found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("skin")]
        public void GetSkin()
        {
            GetCurrentSkinRequestHandler getCurrentSkinRequestHandler = new GetCurrentSkinRequestHandler(_userRepository, _skinRepository);
            getCurrentSkinRequestHandler.Execute(HttpContext);
        }
    }
}
