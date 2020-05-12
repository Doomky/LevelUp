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
        /// Add a new food entry with a specific OpenFoodFacts data id for the user.
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "UserId"
        ///         "OFFDataId"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new food entry was correctly added for the user.</response>
        /// <response code="204">The entry is malformed.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("add")]
        public void AddFoodEntry()
        {
            AddFoodEntryRequestHandler addFoodEntryRequestHandler = new AddFoodEntryRequestHandler(_foodEntryRepository, _offDataRepository, _questRepository, _questTypeRepository, _userRepository);
            addFoodEntryRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Update an existing food entry with a specific OpenFoodFacts data is for the user.
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "Id"
        ///         "UserId"
        ///         "OFFDataId"
        ///         "DateTime"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The new food entry was correctly updated for the user.</response>
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
        /// Remove an existing food entry with a specific id.
        /// </summary>
        /// <remarks>
        /// The body of the request must contains this field:
        /// 
        ///     {
        ///         "Id"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The food entry was correctly removed for the user.</response>
        /// <response code="400">The entry does not exists or the request is malformed or the user does not exists.</response>
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
