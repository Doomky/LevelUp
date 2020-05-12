using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestsController : ControllerBase
    {
        private readonly IQuestRepository _questRepository;
        private readonly IUserRepository _userRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAvatarRepository _avatarRepository;

        public QuestsController(IQuestRepository questRepository, IUserRepository userRepository, IQuestTypeRepository questTypeRepository, ICategoryRepository categoryRepository, IAvatarRepository avatarRepository)
        {
            _questRepository = questRepository;
            _userRepository = userRepository;
            _questTypeRepository = questTypeRepository;
            _categoryRepository = categoryRepository;
            _avatarRepository = avatarRepository;
        }

        /// <summary>
        /// Get the all quests from the signin user. 
        /// </summary>
        /// <response code="200">The quests were found.</response>
        /// <response code="204">The quests are empty.</response>
        /// <response code="400">The user is not signed or does not exist in database.</response>
        [HttpGet]
        public void Get()
        {
            GetQuestRequestHandler getQuestRequestHandler = new GetQuestRequestHandler(_userRepository, _questRepository);
            getQuestRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Get the all quests from the signin user in the specified category. 
        /// </summary>
        /// <response code="200">The quests from the category were found.</response>
        /// <response code="204">The quests from the category are empty.</response>
        /// <response code="400">The user is not signed or does not exist in database or the category does not exist.</response>
        [HttpGet]
        [Route("category/{categoryName}")]
        public void GetByCategory(string categoryName)
        {
            GetQuestByCategoryRequestHandler getQuestByCategoryRequestHandler = new GetQuestByCategoryRequestHandler(_userRepository, _questRepository, _categoryRepository, categoryName);
            getQuestByCategoryRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Update all the quests from the signin user with the given datas. 
        /// </summary>
        /// <response code="200">All the quest have been updated.</response>
        /// <response code="400">The user is not signed or does not exist in database or the data is not formatted correctly.</response>
        [HttpPost]
        [Route("update")]
        public void Update()
        {
            UpdateQuestRequestHandler updateQuestRequestHandler = new UpdateQuestRequestHandler(_userRepository, _questRepository, _questTypeRepository);
            updateQuestRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Add the specified quest to the signin user with the given datas. 
        /// </summary>
        /// <response code="200">All the quest have been updated.</response>
        /// <response code="400">The user is not signed or does not exist in database or the data is not formatted correctly.</response>
        [HttpPost]
        [Route("add")]
        public void Add()
        {
            AddQuestRequestHandler addQuestRequestHandler = new AddQuestRequestHandler(_userRepository, _questRepository, _questTypeRepository, _categoryRepository);
            addQuestRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Remove the specified quest to the signin user. 
        /// </summary>
        /// <response code="200">The quest has been removed.</response>
        /// <response code="400">The user is not signed or does not exist in database or the data is not formatted correctly.</response>
        [HttpPost]
        [Route("remove")]
        public void Remove()
        {
            RemoveQuestRequestHandler removeQuestRequestHandler = new RemoveQuestRequestHandler(_userRepository, _questRepository);
            removeQuestRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Claim the reward for a quest. Send the quest id inside the body.
        /// </summary>
        /// <return>
        /// an object with the fields: state describing the state of the claiming and xp_gained for the xp gained by validating the quest.
        /// </return>
        /// <response code="200">The quest has been claimed. the response has informations on wether the state during the claim</response>
        /// <response code="400">The quest has not been claimed probably because the quest does not exist or still in progress </response>
        [HttpPost]
        [Route("claim")]
        public void Claim()
        {
            ClaimQuestsRequestHandler claimQuestsRequestHandler = new ClaimQuestsRequestHandler(_userRepository, _questRepository, _questTypeRepository, _avatarRepository);
            claimQuestsRequestHandler.Execute(HttpContext);
        }
    }
}