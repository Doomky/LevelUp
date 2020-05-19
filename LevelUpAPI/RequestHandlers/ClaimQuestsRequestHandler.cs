﻿using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class ClaimQuestsRequestHandler : RequestHandler<ClaimQuestsRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly IAvatarRepository _avatarRepository;

        public ClaimQuestsRequestHandler(IUserRepository userRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository, IAvatarRepository avatarRepository)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
            _avatarRepository = avatarRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            Quest quest = _questRepository.GetById(user, Request.QuestId).GetAwaiter().GetResult();
            QuestHandler questHandler = QuestHandlers.Create(quest, _questTypeRepository);
            if (questHandler != null)
            {
                string serializedString = "";
                switch (questHandler.GetState())
                {
                    case QuestState.InProgress:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        context.Response.WriteAsync("you can not claim this quest it's in progress").GetAwaiter().GetResult();
                        return;
                    case QuestState.Failed:
                        _questRepository.Delete(quest.Id).GetAwaiter().GetResult();


                        serializedString = JsonSerializer.Serialize(new { 
                            state = "failed",
                            xp_gain = 0,
                        });
                        break;
                    case QuestState.Finished:
                        var avatar = _avatarRepository.GetByUser(user).GetAwaiter().GetResult();
                        if (avatar != null)
                        {
                            if (quest.XpValue.HasValue)
                            {
                                avatar.Xp += quest.XpValue.Value;
                                while (avatar.Xp >= avatar.XpMax)
                                {
                                    avatar.Level++;
                                    avatar.XpMax *= 2;
                                }

                                _avatarRepository.Update(avatar).GetAwaiter().GetResult();
                            }

                            _questRepository.Delete(quest.Id).GetAwaiter().GetResult();

                            serializedString = JsonSerializer.Serialize(new
                            {
                                state = "finished",
                                xp_gain = quest.XpValue,
                            });
                        }
                        break;
                    default:
                        break;
                }
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(serializedString).GetAwaiter().GetResult();
            }
        }
    }
}
