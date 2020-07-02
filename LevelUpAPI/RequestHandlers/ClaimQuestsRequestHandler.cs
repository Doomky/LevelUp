using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class ClaimQuestsRequestHandler : RequestHandler<ClaimQuestsDTORequest>
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

            Quest quest = _questRepository.GetById(user, Request.questId).GetAwaiter().GetResult();
            QuestHandler questHandler = QuestHandlers.Create(quest, user, _questTypeRepository) ;
            ClaimQuestDTOResponse claimQuestDTOResponse;
            string serializedString;

            if (questHandler != null)
            {
                switch (questHandler.GetState())
                {
                    case QuestState.InProgress:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        claimQuestDTOResponse = new ClaimQuestDTOResponse(questHandler.GetState().ToString(), "0", "you cannot claim this quest, it's in progress");
                        break;
                    case QuestState.Claimed:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        claimQuestDTOResponse = new ClaimQuestDTOResponse(questHandler.GetState().ToString(), "0", "you cannot claim this quest, it was already claimed");
                        break;
                    case QuestState.Failed:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        claimQuestDTOResponse = new ClaimQuestDTOResponse(questHandler.GetState().ToString(), "0", "you cannot claim this quest, it was already failed");
                        break;
                    case QuestState.Finished:
                        context.Response.StatusCode = StatusCodes.Status200OK;
                        quest = _questRepository.SetIsClaimedById(user,quest.Id).GetAwaiter().GetResult();
                        Avatar avatar = _avatarRepository.AddXp(user, quest).GetAwaiter().GetResult();
                        claimQuestDTOResponse = new ClaimQuestDTOResponse(questHandler.GetState().ToString(), quest.XpValue.ToString(), "you have claimed this quest");
                        break;
                    default:
                        throw new NotSupportedException();
                }
                serializedString = JsonSerializer.Serialize(claimQuestDTOResponse);
                dtoResponse = claimQuestDTOResponse;
                context.Response.WriteAsync(serializedString).GetAwaiter().GetResult();
            }
        }
    }
}
