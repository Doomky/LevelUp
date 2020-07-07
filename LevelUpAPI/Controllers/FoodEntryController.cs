using System;
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
        public async Task<IActionResult> Get([FromBody] GetFoodEntriesDTORequest dtoRequest)
        {
            GetFoodEntriesRequestHandler getFoodEntriesRequestHandler = new GetFoodEntriesRequestHandler(User, dtoRequest, _logger, _userRepository, _foodEntryRepository, _offDataRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getFoodEntriesRequestHandler.Handle();
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
        public async Task<IActionResult> GetCount([FromBody] GetFoodEntriesCountDTORequest dtoRequest)
        {
            GetFoodEntriesCountRequestHandler getFoodEntriesCountRequestHandler = new GetFoodEntriesCountRequestHandler(User, dtoRequest, _logger, _userRepository, _foodEntryRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getFoodEntriesCountRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Add a new food entry with a specific OpenFoodFacts data id for the signed-in user.
        /// </summary>
        /// <remarks>
        /// The body of the request must contains this field:
        /// 
        ///     {
        ///         "Name" 
        ///         "Energy100g"
        ///         "Sodium100g"
        ///         "Salt100g"
        ///         "Fat100g"
        ///         "SaturatedFat100g"
        ///         "Proteins100g" 
        ///         "Sugars100g"
        ///         "EnergyServing" 
        ///         "SodiumServing"
        ///         "SaltServing"
        ///         "FatServing" 
        ///         "SaturatedFatServing" 
        ///         "ProteinsServing"
        ///         "SugarsServing" 
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new food entry was correctly added.</response>
        /// <response code="204">The entry is malformed.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("add/custom")]
        public async Task<IActionResult> AddCustom([FromBody] AddCustomFoodEntryDTORequest dtoRequest)
        {
            AddCustomFoodEntryRequestHandler addCustomFoodEntryRequestHandler = new AddCustomFoodEntryRequestHandler(User, dtoRequest, _logger, _foodEntryRepository, _userRepository, _offDataRepository, _questRepository, _questTypeRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await addCustomFoodEntryRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Add a new food entry with a specific OpenFoodFacts data id for the signed-in user.
        /// </summary>
        /// <remarks>
        /// The body of the request must contains this field:
        /// 
        ///     {
        ///         "OFFDataId"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new food entry was correctly added.</response>
        /// <response code="204">The entry is malformed.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] AddFoodEntryDTORequest dtoRequest)
        {
            AddFoodEntryRequestHandler addFoodEntryRequestHandler = new AddFoodEntryRequestHandler(User, dtoRequest, _logger, _foodEntryRepository, _offDataRepository, _questRepository, _questTypeRepository, _userRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await addFoodEntryRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Update an existing food entry with a specific OpenFoodFacts data is for the signed-in user.
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "Id"
        ///         "OFFDataId"
        ///         "DateTime"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new food entry was correctly updated.</response>
        /// <response code="400">The entry does not exists or the request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateFoodEntryDTORequest dtoRequest)
        {
            UpdateFoodEntryRequestHandler updateFoodEntryRequestHandler = new UpdateFoodEntryRequestHandler(_userRepository, _foodEntryRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await updateFoodEntryRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Remove an existing food entry with a specific id for the signed-in user.
        /// </summary>
        /// <remarks>
        /// The body of the request must contains this field:
        /// 
        ///     {
        ///         "Id"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The food entry was correctly removed.</response>
        /// <response code="400">The entry does not exists or the request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove([FromBody] RemoveFoodEntryDTORequest dtoRequest)
        {
            RemoveFoodEntryRequestHandler removeFoodEntryRequestHandler = new RemoveFoodEntryRequestHandler(User, dtoRequest, _logger, _userRepository, _foodEntryRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await removeFoodEntryRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }
    }
}
