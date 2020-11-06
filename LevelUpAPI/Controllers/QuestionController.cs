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
        private readonly ILogger<UsersController> logger;
        private readonly levelupContext context;

        public QuestionController(IQuestionRepository questionRepository, ILogger<UsersController> logger, levelupContext context)
        {
            _questionRepository = questionRepository;
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public void Get()
        {
            GetQuestionRequestHandler questionRequestHandler = new GetQuestionRequestHandler(_questionRepository);
            questionRequestHandler.Execute(HttpContext);
        }
    }
}
