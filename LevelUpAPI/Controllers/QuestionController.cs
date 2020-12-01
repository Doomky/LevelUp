using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Model;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAvatarRepository _avatarRepository;
        private readonly ILogger<UsersController> logger;
        private readonly levelupContext context;

        public QuestionController(IQuestionRepository questionRepository, IUserRepository userRepository, IAvatarRepository avatarRepository, ILogger<UsersController> logger, levelupContext context)
        {
            _questionRepository = questionRepository;
            _userRepository = userRepository;
            _avatarRepository = avatarRepository;
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public void Get()
        {
            GetQuestionRequestHandler questionRequestHandler = new GetQuestionRequestHandler(_questionRepository);
            questionRequestHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("Score")]
        public void PostQuizScoreAndEarnXP()
        {
            PostQuizScoreRequestHandler postQuizResultsRequestHandler = new PostQuizScoreRequestHandler(_userRepository, _avatarRepository);
            postQuizResultsRequestHandler.Execute(HttpContext);
        }
    }
}
