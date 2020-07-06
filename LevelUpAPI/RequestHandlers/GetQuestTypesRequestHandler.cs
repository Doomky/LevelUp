using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestTypesRequestHandler : RequestHandler<GetQuestTypesDTORequest, GetQuestTypesDTOResponse>
    {
        private readonly IQuestTypeRepository _questTypeRepository;

        public GetQuestTypesRequestHandler(IQuestTypeRepository questTypeRepository, GetQuestTypesDTORequest dTORequest, ILogger logger) : base(dTORequest,logger)
        {
            _questTypeRepository = questTypeRepository;
        }

        protected override Task<(GetQuestTypesDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            IEnumerable<QuestType> questTypes = await _questTypeRepository.GetAllQuestTypes();

            GetQuestTypesDTOResponse getQuestTypesDTOResponse = new GetQuestTypesDTOResponse()
            {

            };

            return (getQuestTypesDTOResponse, HttpStatusCode.OK, null);
        }
    }
}
