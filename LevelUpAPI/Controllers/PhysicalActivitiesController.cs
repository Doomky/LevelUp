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
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public PhysicalActivitiesController(IUserRepository userRepository, IPhysicalActivitiesRepository physicalActivitiesRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository)
        {
            _userRepository = userRepository;
            _physicalActivitiesRepository = physicalActivitiesRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
        }

        /// <summary>
        /// Get all the physical activity entries of the signed-in user. 
        /// </summary>
        /// <response code="200">The physical activity entries were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        public void Get()
        {
            GetPAEntriesRequestHandler getPAEntriesRequestHandler = new GetPAEntriesRequestHandler(_userRepository, _physicalActivitiesEntryRepository);
            getPAEntriesRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Add a new physical activity entry for the signed-in user. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "Name"
        ///         "kCalPerHour"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The physical activity entry was correctly added.</response>
        /// <response code="204">The entry is malformed.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("add")]
        public void Add()
        {
            AddPAEntryRequestHandler addPAEntryRequestHandler = new AddPAEntryRequestHandler(_userRepository, _physicalActivitiesRepository, _physicalActivitiesEntryRepository);
            addPAEntryRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Update a physical activity entry for the signed-in user. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "Id"
        ///         "NewName"
        ///         "NewKCalPerHour"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The physical activity entry was correctly updated.</response>
        /// <response code="204">The entry is malformed.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("update")]
        public void Update()
        {
            UpdatePAEntryRequestHandler updatePAEntryRequestHandler = new UpdatePAEntryRequestHandler(_userRepository, _physicalActivitiesRepository, _physicalActivitiesEntryRepository);
            updatePAEntryRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Remove a physical activity entry for the signed-in user. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains this field:
        /// 
        ///     {
        ///         "Id"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The physical activity entry was correctly removed.</response>
        /// <response code="204">The entry is malformed.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("remove")]
        public void Remove()
        {
            RemovePAEntryRequestHandler removePAEntryRequestHandler = new RemovePAEntryRequestHandler(_userRepository, _physicalActivitiesEntryRepository);
            removePAEntryRequestHandler.Execute(HttpContext);
        }
    }
}
