using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Helpers;
using LevelUpAPI.RequestHandlers;
using LevelUpDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhysicalActivitiesController : ControllerBase
    {
        private readonly ILogger<PhysicalActivitiesController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly IQuestRepository _questRepository;

        public PhysicalActivitiesController(ILogger<PhysicalActivitiesController> logger, IUserRepository userRepository, IPhysicalActivitiesRepository physicalActivitiesRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository, IQuestTypeRepository questTypeRepository, IQuestRepository questRepository)
        {
            _logger = logger;
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
        public async Task<ActionResult<GetPADTOResponse>> Get()
        {
            GetPADTORequest dtoRequest = new GetPADTORequest();
            GetPARequestHandler getPARequestHandler = new GetPARequestHandler(User, dtoRequest, _logger,_physicalActivitiesRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getPARequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
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
        public async Task<ActionResult<AddPADTOResponse>>  Add([FromBody] AddPADTORequest dtoRequest)
        {
            AddPARequestHandler addPARequestHandler = new AddPARequestHandler(User, dtoRequest, _logger, _physicalActivitiesRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await addPARequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Get all the physical activity entries of the signed-in user. 
        /// </summary>
        /// <response code="200">The physical activity entries were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("entry/")]
        public async Task<ActionResult<GetPAEntriesDTOResponse>>  GetEntries()
        {
            GetPAEntriesDTORequest dtoRequest = new GetPAEntriesDTORequest();
            GetPAEntriesRequestHandler getPAEntriesRequestHandler = new GetPAEntriesRequestHandler(User, dtoRequest, _logger, _userRepository, _physicalActivitiesEntryRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getPAEntriesRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Get the total entries for each physical activity of the signed-in user. 
        /// </summary>
        /// <response code="200">The physical activity entries were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("entry/total")]
        public async Task<ActionResult<GetTotalPAEntriesDTOResponse>>  GetTotalEntries()
        {
            GetTotalPAEntriesDTORequest dtoRequest = new GetTotalPAEntriesDTORequest();
            GetTotalPAEntriesRequestHandler getTotalPAEntriesRequestHandler = new GetTotalPAEntriesRequestHandler(User, dtoRequest, _logger, _userRepository, _physicalActivitiesEntryRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getTotalPAEntriesRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
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
        public async Task<ActionResult<AddPAEntryDTOResponse>> AddEntry([FromBody] AddPAEntryDTORequest dtoRequest)
        {
            AddPAEntryRequestHandler addPAEntryRequestHandler = new AddPAEntryRequestHandler(User, dtoRequest, _logger, _userRepository, _physicalActivitiesRepository, _physicalActivitiesEntryRepository, _questTypeRepository, _questRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await addPAEntryRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
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
        public async Task<ActionResult<UpdatePAEntryDTOResponse>> UpdateEntry([FromBody] UpdatePAEntryDTORequest dtoRequest)
        {
            UpdatePAEntryRequestHandler updatePAEntryRequestHandler = new UpdatePAEntryRequestHandler(_userRepository, _physicalActivitiesRepository, _physicalActivitiesEntryRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await updatePAEntryRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
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
        public async Task<ActionResult<RemoveFoodEntryDTOResponse>>  RemoveEntry([FromBody] RemovePAEntryDTORequest dtoRequest)
        {
            RemovePAEntryRequestHandler removePAEntryRequestHandler = new RemovePAEntryRequestHandler(_userRepository, _physicalActivitiesEntryRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await removePAEntryRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }
    }
}
