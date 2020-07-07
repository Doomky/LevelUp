﻿using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class ClaimQuestsRequestHandler : RequestHandler<ClaimQuestsDTORequest, ClaimQuestsDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly IAvatarRepository _avatarRepository;

        public ClaimQuestsRequestHandler(ClaimsPrincipal claims, ClaimQuestsDTORequest dtoRequest, ILogger logger, IUserRepository userRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository, IAvatarRepository avatarRepository) : base(claims, dtoRequest, logger)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
            _avatarRepository = avatarRepository;
        }

        protected async override Task<(ClaimQuestsDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            Quest quest = await _questRepository.GetById(user, DTORequest.questId);
            QuestHandler questHandler = QuestHandlers.Create(quest, user, _questTypeRepository);
            ClaimQuestsDTOResponse claimQuestDTOResponse;
            string serializedString;

            if (questHandler != null)
            {
                switch (questHandler.GetState())
                {
                    case QuestState.InProgress:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        claimQuestDTOResponse = new ClaimQuestsDTOResponse(QuestState.InProgress.ToString(), "0", "you cannot claim this quest, it's in progress");
                        break;
                    case QuestState.Claimed:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        claimQuestDTOResponse = new ClaimQuestsDTOResponse(QuestState.Claimed.ToString(), "0", "you cannot claim this quest, it was already claimed");
                        break;
                    case QuestState.Failed:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        claimQuestDTOResponse = new ClaimQuestsDTOResponse(QuestState.Failed.ToString(), "0", "you cannot claim this quest, it was already failed");
                        break;
                    case QuestState.Finished:
                        context.Response.StatusCode = StatusCodes.Status200OK;
                        quest = _questRepository.SetIsClaimedById(user,quest.Id).GetAwaiter().GetResult();
                        _avatarRepository.AddXp(user, quest).GetAwaiter().GetResult();
                        claimQuestDTOResponse = new ClaimQuestsDTOResponse(QuestState.Finished.ToString(), quest.XpValue.ToString(), "you have claimed this quest");
                        break;
                    default:
                        throw new NotSupportedException();
                }
                serializedString = JsonSerializer.Serialize(claimQuestDTOResponse);
                context.Response.WriteAsync(serializedString).GetAwaiter().GetResult();
                return claimQuestDTOResponse;
            }
            return null;
        }
    }
}
