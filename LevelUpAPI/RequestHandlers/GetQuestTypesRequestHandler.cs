using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using static LevelUpDTO.GetQuestTypesDTOResponse;

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestTypesRequestHandler : RequestHandler<GetQuestTypesDTORequest, GetQuestTypesDTOResponse>
    {
        private readonly IQuestTypeRepository _questTypeRepository;

        public GetQuestTypesRequestHandler(IQuestTypeRepository questTypeRepository, ClaimsPrincipal claims, GetQuestTypesDTORequest dTORequest, ILogger logger) : base(claims, dTORequest,logger)
        {
            _questTypeRepository = questTypeRepository;
        }

        protected async override Task<(GetQuestTypesDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            IEnumerable<QuestType> questTypes = _questTypeRepository.GetAllQuestTypes();

            if (questTypes == null)
                return (null, HttpStatusCode.BadRequest, "Cannot get the quest types");

            List<QuestTypesDTOResponse> questTypesDTOs = questTypes.Select(questType => 
                new QuestTypesDTOResponse(questType.Id, questType.Name)
            ).ToList();

            GetQuestTypesDTOResponse getQuestTypesDTOResponse = new GetQuestTypesDTOResponse(questTypesDTOs);
            
            return (getQuestTypesDTOResponse, HttpStatusCode.OK, null);
        }
    }
}
