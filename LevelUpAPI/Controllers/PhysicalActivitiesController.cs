using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhysicalActivitiesController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public PhysicalActivitiesController(IUserRepository userRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository)
        {
            _userRepository = userRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
        }

        /// <summary>
        /// Get all the physical activity entries of the signed-in user. 
        /// </summary>
        /// <response code="200">The physical activities were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        public void Get()
        {
            GetPAEntriesRequestHandler getPAEntriesRequestHandler = new GetPAEntriesRequestHandler(_userRepository, _physicalActivitiesEntryRepository);
            getPAEntriesRequestHandler.Execute(HttpContext);
        }
    }
}
