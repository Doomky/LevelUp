using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Mvc;
using static LevelUpAPI.Helpers.StringHelpers;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System.Net;
using LevelUpAPI.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestsController : ControllerBase
    {
        private readonly ILogger<QuestsController> _logger;
        private readonly IQuestRepository _questRepository;
        private readonly IUserRepository _userRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAvatarRepository _avatarRepository;

        public QuestsController(ILogger<QuestsController> logger, IQuestRepository questRepository, IUserRepository userRepository, IQuestTypeRepository questTypeRepository, ICategoryRepository categoryRepository, IAvatarRepository avatarRepository)
        {
            _logger = logger;
            _questRepository = questRepository;
            _userRepository = userRepository;
            _questTypeRepository = questTypeRepository;
            _categoryRepository = categoryRepository;
            _avatarRepository = avatarRepository;
        }

        /// <summary>
        /// Get all the quests of the signed-in user. you can specify the state of the quest in the route to get only "inprogress", "finished" or "failed" quests 
        /// </summary>
        /// <response code="200">The quests were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("{questStateName?}")]
        public async Task<ActionResult<List<GetQuestDTOResponse.QuestDTOResponse1>>> Get([FromRoute] string questStateName)
        {
            QuestState? questState = questStateName.AsQuestStateEnum();
            GetQuestDTORequest dtoRequest = new GetQuestDTORequest();
            dtoRequest.QuestState = questStateName;
            GetQuestRequestHandler getQuestRequestHandler = new GetQuestRequestHandler(questState, User, dtoRequest, _logger, _userRepository, _questRepository, _questTypeRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getQuestRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse.QuestDTOResponses);
        }

        /// <summary>
        /// Get the list of all the available quest categories. 
        /// </summary>
        /// <response code="200">The request succedded.</response>
        /// <response code="400">The request is malformed.</response>
        [HttpGet]
        [Route("category/list")]
        public async Task<ActionResult<List<GetQuestCategoriesDTOResponse.CategoryDTOResponse>>> GetQuestCategories()
        {
            GetQuestCategoriesDTORequest dtoRequest = new GetQuestCategoriesDTORequest();
            GetQuestCategoriesRequestHandler getQuestCategoriesRequestHandler = new GetQuestCategoriesRequestHandler(User, dtoRequest, _logger, _categoryRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getQuestCategoriesRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse.Categories);
        }

        /// <summary>
        /// Get all the quests of the signed-in user in the specified category. 
        /// </summary>
        /// <param name="categoryName">The category name the user want to get his quests for.</param>
        /// <response code="200">The quests from the category were found.</response>
        /// <response code="400">The request is malformed or the user does not exist or the category does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        [Route("category/{categoryName}")]
        public async Task<ActionResult<List<GetQuestByCategoryDTOResponse.QuestDTOResponse2>>> GetByCategory([FromRoute] string categoryName)
        {
            GetQuestByCategoryDTORequest dtoRequest = new GetQuestByCategoryDTORequest();
            dtoRequest.Category = categoryName;
            GetQuestByCategoryRequestHandler getQuestByCategoryRequestHandler = new GetQuestByCategoryRequestHandler(User, dtoRequest, _logger, _userRepository, _questRepository, _categoryRepository, _questTypeRepository, categoryName);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getQuestByCategoryRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse.Quests);
        }

        /// <summary>
        /// Get the list of all the available quest types. 
        /// </summary>
        /// <response code="200">The request succedded.</response>
        /// <response code="400">The request is malformed.</response>
        [HttpGet]
        [Route("type/list")]
        public async Task<ActionResult<GetQuestTypesDTOResponse>> GetQuestTypes()
        {
            GetQuestTypesDTORequest dtoRequest = new GetQuestTypesDTORequest();
            GetQuestTypesRequestHandler getQuestTypesRequestHandler = new GetQuestTypesRequestHandler(_questTypeRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getQuestTypesRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Update all the quests of the signed-in user with the given data. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains this field:
        /// 
        ///     {
        ///         "Data"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">All the quests have been correctly updated.</response>
        /// <response code="400">The request is malformed or the user does not exist or the data is not formatted correctly.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<List<UpdateQuestDTOResponse.Quest>>> Update([FromBody] UpdateQuestDTORequest dtoRequest)
        {
            UpdateQuestRequestHandler updateQuestRequestHandler = new UpdateQuestRequestHandler(_userRepository, _questRepository, _questTypeRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await updateQuestRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse.Quests);
        }

        /// <summary>
        /// Add the specified quest to the signed-in user with the given data. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "CategoryId"
        ///         "TypeId"
        ///         "Data"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The quest has been correclty created.</response>
        /// <response code="204">The data is not formatted correctly.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<AddQuestDTOResponse>> Add([FromBody] AddQuestDTORequest dtoRequest)
        {
            AddQuestRequestHandler addQuestRequestHandler = new AddQuestRequestHandler(User, dtoRequest, _logger, _userRepository, _questRepository, _questTypeRepository, _categoryRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await addQuestRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Remove the specified quest of the signed-in user. 
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "QuestId"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The quest has been removed.</response>
        /// <response code="400">The user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("remove")]
        public async Task<ActionResult<RemoveQuestDTOResponse>> Remove([FromBody] RemoveQuestDTORequest dtoRequest)
        {
            RemoveQuestRequestHandler removeQuestRequestHandler = new RemoveQuestRequestHandler(_userRepository, _questRepository, User, dtoRequest, _logger);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await removeQuestRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }

        /// <summary>
        /// Claim the reward for a specified quest of the signed-in user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /quests/claim
        ///     {
        ///        "questId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>The state, the xp gain of the quest and a message.</returns>
        /// <response code="200">The quest has been claimed. The response contains informations on the state of the quest during the claim.</response>
        /// <response code="400">The quest has not been claimed because the quest does not exist or is still in progress.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("claim")]
        public async Task<ActionResult<ClaimQuestsDTOResponse>> Claim([FromBody] ClaimQuestsDTORequest dtoRequest)
        {
            ClaimQuestsRequestHandler claimQuestsRequestHandler = new ClaimQuestsRequestHandler(User, dtoRequest, _logger, _userRepository, _questRepository, _questTypeRepository, _avatarRepository);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await claimQuestsRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }
    }
}