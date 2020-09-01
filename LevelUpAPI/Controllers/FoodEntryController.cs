using System;
using System.Collections.Generic;
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
    public class FoodEntryController : ControllerBase
    {
        private readonly ILogger<FoodEntryController> _logger;
        private readonly IFoodEntryRepository _foodEntryRepository;
        private readonly IOFFDataRepository _offDataRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly IUserRepository _userRepository;

        public FoodEntryController(ILogger<FoodEntryController> logger, IFoodEntryRepository foodEntryRepository, IOFFDataRepository offDataRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _foodEntryRepository = foodEntryRepository;
            _offDataRepository = offDataRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all the food entries of the signed-in user.
        /// </summary>
        /// <response code="200">The food entries were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        public async Task<ActionResult<GetFoodEntriesDTOResponse>> Get()
        {
            GetFoodEntriesDTORequest dtoRequest = new GetFoodEntriesDTORequest();
            GetFoodEntriesRequestHandler getFoodEntriesRequestHandler = new GetFoodEntriesRequestHandler(User, dtoRequest, _logger, _userRepository, _foodEntryRepository, _offDataRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getFoodEntriesRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Get the count of each type of food entries of the signed-in user.
        /// </summary>
        /// <response code="200">The food entries were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("count")]
        public async Task<ActionResult<GetFoodEntriesCountDTOResponse>> GetCount()
        {
            GetFoodEntriesCountDTORequest dtoRequest = new GetFoodEntriesCountDTORequest();
            GetFoodEntriesCountRequestHandler getFoodEntriesCountRequestHandler = new GetFoodEntriesCountRequestHandler(User, dtoRequest, _logger, _userRepository, _foodEntryRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getFoodEntriesCountRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Add a new food entry with custom data for the signed-in user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /foodentry/add/custom
        ///     {
        ///         "name": "Lipton Ice Tea peach flavored - 33 cL",
        ///         "energy100g": 20,
        ///         "sodium100g": 0,
        ///         "salt100g": 0,
        ///         "fat100g": 0,
        ///         "saturatedFat100g": 0,
        ///         "proteins100g": 0,
        ///         "sugars100g": 4.5,
        ///         "energyServing": 66,
        ///         "sodiumServing": 0,
        ///         "saltServing": 0,
        ///         "fatServing": 0,
        ///         "saturatedFatServing": 0,
        ///         "proteinsServing": 0,
        ///         "sugarsServing": 14.8
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new food entry was correctly added.</response>
        /// <response code="204">The entry is malformed.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("add/custom")]
        public async Task<ActionResult<AddCustomFoodEntryDTOResponse>> AddCustom([FromBody] AddCustomFoodEntryDTORequest dtoRequest)
        {
            AddCustomFoodEntryRequestHandler addCustomFoodEntryRequestHandler = new AddCustomFoodEntryRequestHandler(User, dtoRequest, _logger, _foodEntryRepository, _userRepository, _offDataRepository, _questRepository, _questTypeRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await addCustomFoodEntryRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Add a new food entry with a specific OpenFoodFacts data id for the signed-in user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /foodentry/add
        ///     {
        ///         "offDataId": 4
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new food entry was correctly added.</response>
        /// <response code="204">The entry is malformed.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<AddFoodEntryDTOResponse>> Add([FromBody] AddFoodEntryDTORequest dtoRequest)
        {
            AddFoodEntryRequestHandler addFoodEntryRequestHandler = new AddFoodEntryRequestHandler(User, dtoRequest, _logger, _foodEntryRepository, _offDataRepository, _questRepository, _questTypeRepository, _userRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await addFoodEntryRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Update an existing food entry with a specific OpenFoodFacts data is for the signed-in user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /foodentry/update
        ///     {
        ///         "id": 4,
        ///         "offDataId": 8
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new food entry was correctly updated.</response>
        /// <response code="400">The entry does not exists or the request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UpdateFoodEntryDTOResponse>> Update([FromBody] UpdateFoodEntryDTORequest dtoRequest)
        {
            UpdateFoodEntryRequestHandler updateFoodEntryRequestHandler = new UpdateFoodEntryRequestHandler(_userRepository, _foodEntryRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await updateFoodEntryRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Remove an existing food entry with a specific id for the signed-in user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /foodentry/remove
        ///     {
        ///         "id": 12
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The food entry was correctly removed.</response>
        /// <response code="400">The entry does not exists or the request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("remove")]
        public async Task<ActionResult<RemoveFoodEntryDTOResponse>> Remove([FromBody] RemoveFoodEntryDTORequest dtoRequest)
        {
            RemoveFoodEntryRequestHandler removeFoodEntryRequestHandler = new RemoveFoodEntryRequestHandler(User, dtoRequest, _logger, _userRepository, _foodEntryRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await removeFoodEntryRequestHandler.Handle();
            if (statusCode != HttpStatusCode.OK && err != null)
                _logger.LogError(err);
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }
    }
}
