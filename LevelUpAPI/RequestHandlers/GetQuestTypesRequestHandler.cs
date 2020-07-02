using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestTypesRequestHandler : RequestHandler<GetQuestTypesDTORequest>
    {
        private readonly IQuestTypeRepository _questTypeRepository;

        public GetQuestTypesRequestHandler(IQuestTypeRepository questTypeRepository)
        {
            _questTypeRepository = questTypeRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            IEnumerable<QuestType> questTypes = _questTypeRepository.GetAllQuestTypes();

            if (questTypes != null)
            {
                string questTypesJson = JsonSerializer.Serialize(questTypes);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(questTypesJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
