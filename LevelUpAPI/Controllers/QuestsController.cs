﻿using System;
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
        /// Get all the quests of the signed-in user. 
        /// </summary>
        /// <response code="200">The quests were found.</response>
        /// <response code="400">The request is malformed or the user does not exist.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpGet]
        public void Get()
        {
            GetQuestRequestHandler getQuestRequestHandler = new GetQuestRequestHandler(_userRepository, _questRepository);
            getQuestRequestHandler.Execute(HttpContext);
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
        public void GetByCategory(string categoryName)
        {
            GetQuestByCategoryRequestHandler getQuestByCategoryRequestHandler = new GetQuestByCategoryRequestHandler(_userRepository, _questRepository, _categoryRepository, categoryName);
            getQuestByCategoryRequestHandler.Execute(HttpContext);
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
        public void Update()
        {
            UpdateQuestRequestHandler updateQuestRequestHandler = new UpdateQuestRequestHandler(_userRepository, _questRepository, _questTypeRepository);
            updateQuestRequestHandler.Execute(HttpContext);
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
        public void Add()
        {
            AddQuestRequestHandler addQuestRequestHandler = new AddQuestRequestHandler(_userRepository, _questRepository, _questTypeRepository, _categoryRepository);
            addQuestRequestHandler.Execute(HttpContext);
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
        public void Remove()
        {
            RemoveQuestRequestHandler removeQuestRequestHandler = new RemoveQuestRequestHandler(_userRepository, _questRepository);
            removeQuestRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Claim the reward for a specified quest of the signed-in user.
        /// </summary>
        /// <remarks>
        /// The body of the request must contains those fields:
        /// 
        ///     {
        ///         "QuestId"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">The quest has been claimed. The response contains informations on the state of the quest during the claim.</response>
        /// <response code="400">The quest has not been claimed because the quest does not exist or is still in progress.</response>
        /// <response code="401">The user is not signed in.</response>
        [HttpPost]
        [Route("claim")]
        public void Claim()
        {
            ClaimQuestsRequestHandler claimQuestsRequestHandler = new ClaimQuestsRequestHandler(_userRepository, _questRepository, _questTypeRepository, _avatarRepository);
            claimQuestsRequestHandler.Execute(HttpContext);
        }
    }
}