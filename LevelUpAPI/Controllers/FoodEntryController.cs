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
        private readonly IUserRepository _userRepository;
        private readonly IFoodEntryRepository _foodEntryRepository;

        public FoodEntryController(IUserRepository userRepository, IFoodEntryRepository foodEntryRepository)
        {
            _userRepository = userRepository;
            _foodEntryRepository = foodEntryRepository;
        }

        /// <summary>
        /// Get all the food entries of the signed-in user.
        /// </summary>
        /// <response code="200">The food entries were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        public void GetFoodEntries()
        {
            GetFoodEntriesRequestHandler getFoodEntriesRequestHandler = new GetFoodEntriesRequestHandler(_userRepository, _foodEntryRepository);
            getFoodEntriesRequestHandler.Execute(HttpContext);
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
        public void AddFoodEntry()
        {
            AddFoodEntryRequestHandler addFoodEntryRequestHandler = new AddFoodEntryRequestHandler(_userRepository, _foodEntryRepository);
            addFoodEntryRequestHandler.Execute(HttpContext);
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
        public void UpdateFoodEntry()
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
        public void RemoveFoodEntry()
        {
            RemoveFoodEntryRequestHandler removeFoodEntryRequestHandler = new RemoveFoodEntryRequestHandler(_userRepository, _foodEntryRepository);
            removeFoodEntryRequestHandler.Execute(HttpContext);
        }
    }
}
