using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public AvatarController(ILogger<UsersController> logger, levelupContext context, IAvatarRepository avatarRepository, IUserRepository userRepository, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
            _configuration = configuration;
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
    }
}
