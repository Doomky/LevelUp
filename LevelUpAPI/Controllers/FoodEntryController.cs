using System;
using System.Threading.Tasks;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FoodEntryController : ControllerBase
    {
        private readonly IFoodEntryRepository _foodEntryRepository;
        private readonly IOFFDataRepository _offDataRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly IUserRepository _userRepository;

        public FoodEntryController(IFoodEntryRepository foodEntryRepository, IOFFDataRepository offDataRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository, IUserRepository userRepository)
        {
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
        public void Get()
        {
            GetFoodEntriesRequestHandler getFoodEntriesRequestHandler = new GetFoodEntriesRequestHandler(_userRepository, _foodEntryRepository, _offDataRepository);
            getFoodEntriesRequestHandler.Handle(HttpContext);
        }

        /// <summary>
        /// Get the count of each type of food entries of the signed-in user.
        /// </summary>
        /// <response code="200">The food entries were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("count")]
        public void GetCount()
        {
            GetFoodEntriesCountRequestHandler getFoodEntriesCountRequestHandler = new GetFoodEntriesCountRequestHandler(_userRepository, _foodEntryRepository);
            getFoodEntriesCountRequestHandler.Handle(HttpContext);
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
        public void AddCustom()
        {
            AddCustomFoodEntryRequestHandler addCustomFoodEntryRequestHandler = new AddCustomFoodEntryRequestHandler(_foodEntryRepository, _userRepository, _offDataRepository, _questRepository, _questTypeRepository);
            addCustomFoodEntryRequestHandler.Handle(HttpContext);
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
        public void Add()
        {
            AddFoodEntryRequestHandler addFoodEntryRequestHandler = new AddFoodEntryRequestHandler(_foodEntryRepository, _offDataRepository, _questRepository, _questTypeRepository, _userRepository);
            addFoodEntryRequestHandler.Handle(HttpContext);
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
        public void Update()
        {
            UpdateFoodEntryRequestHandler updateFoodEntryRequestHandler = new UpdateFoodEntryRequestHandler(_userRepository, _foodEntryRepository);
            updateFoodEntryRequestHandler.Execute(HttpContext);
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
        public void Remove()
        {
            RemoveFoodEntryRequestHandler removeFoodEntryRequestHandler = new RemoveFoodEntryRequestHandler(_userRepository, _foodEntryRepository);
            removeFoodEntryRequestHandler.Execute(HttpContext);
        }
    }
}
