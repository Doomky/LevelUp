using LevelUpAPI.DataAccess.Repositories;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO.Requests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestionRequestHandler : RequestHandler<GetQuestionDTORequest>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionRequestHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            IEnumerable<Question> questions = _questionRepository.Get10().GetAwaiter().GetResult();

            if (questions != null)
            {
                string questionsJson = JsonSerializer.Serialize(new{ questions = questions});
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(questionsJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
