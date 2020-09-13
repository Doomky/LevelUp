using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.DataAccess.Repositories;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Model;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdviceController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly levelupContext _context;
        private readonly IAdviceRepository _adviceRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AdviceController(ILogger<UsersController> logger, levelupContext context, IAdviceRepository adviceRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _context = context;
            _adviceRepository = adviceRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Get all the info about the avatar of the signed-in user.
        /// </summary>
        /// <response code="200">The info about the avatar were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("{categoryName}")]
        public void Get(string categoryName)
        {
            GetAdviceByCategoryRequestHandler getAdviceByCategoryRequestHandler = new GetAdviceByCategoryRequestHandler(_userRepository, _adviceRepository, _categoryRepository, categoryName);
            getAdviceByCategoryRequestHandler.Execute(HttpContext);
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
            GetAdviceByCategoryRequestHandler getAdviceByCategoryRequestHandler = new GetAdviceByCategoryRequestHandler(_userRepository, _adviceRepository, _categoryRepository, null);
            getAdviceByCategoryRequestHandler.Execute(HttpContext);
        }


    }
}