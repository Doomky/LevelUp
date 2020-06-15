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
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly IQuestRepository _questRepository;

        public PhysicalActivitiesController(IUserRepository userRepository, IPhysicalActivitiesRepository physicalActivitiesRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository, IQuestTypeRepository questTypeRepository, IQuestRepository questRepository)
        {
            _userRepository = userRepository;
            _physicalActivitiesRepository = physicalActivitiesRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
            _questTypeRepository = questTypeRepository;
            _questRepository = questRepository;
        }

        /// <summary>
        /// Get the list of all the possible physical activities. 
        /// </summary>
        /// <response code="200">The request succedded.</response>
        /// <response code="400">The request is malformed.</response>
        [HttpGet]
        public void Get()
        {
            GetPARequestHandler getPARequestHandler = new GetPARequestHandler(_physicalActivitiesRepository);
            getPARequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Add a new physical activity. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "Name"
        ///         "CalPerKgPerHour"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The physical activity entry was correctly added.</response>
        /// <response code="204">The entry is malformed.</response>
        /// <response code="400">The request is malformed.</response>
        [HttpPost]
        [Route("add")]
        public void Add()
        {
            AddPARequestHandler addPARequestHandler = new AddPARequestHandler(_physicalActivitiesRepository);
            addPARequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Get all the physical activity entries of the signed-in user. 
        /// </summary>
        /// <response code="200">The physical activity entries were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("entry/")]
        public void GetEntries()
        {
            GetPAEntriesRequestHandler getPAEntriesRequestHandler = new GetPAEntriesRequestHandler(_userRepository, _physicalActivitiesEntryRepository);
            getPAEntriesRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Get the total entries for each physical activity of the signed-in user. 
        /// </summary>
        /// <response code="200">The physical activity entries were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("entry/total")]
        public void GetTotalEntries()
        {
            GetTotalPAEntriesRequestHandler getTotalPAEntriesRequestHandler = new GetTotalPAEntriesRequestHandler(_userRepository, _physicalActivitiesEntryRepository);
            getTotalPAEntriesRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Add a new physical activity entry for the signed-in user. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "Name"
        ///         "dateTimeStart"
        ///         "dateTimeEnd"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The physical activity entry was correctly added.</response>
        /// <response code="204">The entry is malformed or the physical activity does not exist in database.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("entry/add")]
        public void AddEntry()
        {
            AddPAEntryRequestHandler addPAEntryRequestHandler = new AddPAEntryRequestHandler(_userRepository, _physicalActivitiesRepository, _physicalActivitiesEntryRepository, _questTypeRepository, _questRepository);
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
        ///         "NewDateTimeStart"
        ///         "NewDateTimeEnd"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The physical activity entry was correctly updated.</response>
        /// <response code="204">The entry is malformed.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("entry/update")]
        public void UpdateEntry()
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
        [Route("entry/remove")]
        public void RemoveEntry()
        {
            RemovePAEntryRequestHandler removePAEntryRequestHandler = new RemovePAEntryRequestHandler(_userRepository, _physicalActivitiesEntryRepository);
            removePAEntryRequestHandler.Execute(HttpContext);
        }
    }
}
