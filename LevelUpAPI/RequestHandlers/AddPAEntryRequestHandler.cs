using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;

namespace LevelUpAPI.RequestHandlers
{
    public class AddPAEntryRequestHandler : RequestHandler<AddPAEntryDTORequest, AddPAEntryDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly IQuestRepository _questRepository;

        public AddPAEntryRequestHandler(IUserRepository userRepository, IPhysicalActivitiesRepository physicalActivitiesRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository, IQuestTypeRepository questTypeRepository, IQuestRepository questRepository)
        {
            _userRepository = userRepository;
            _physicalActivitiesRepository = physicalActivitiesRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
            _questTypeRepository = questTypeRepository;
            _questRepository = questRepository;
        }

        protected override async Task<AddPAEntryDTOResponse> ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(DTORequest, context, _userRepository);
            if (!isOk || user == null)
                return null;

            PhysicalActivity PA = _physicalActivitiesRepository.GetPhysicalActivity(DTORequest.Name);
            if (PA == null)
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return null;
            }

            PhysicalActivityEntry PAEntry = _physicalActivitiesEntryRepository.Insert(new PhysicalActivityEntry()
            {
                UserId = user.Id,
                PhysicalActivitiesId = PA.Id,
                DatetimeStart = DateTime.Parse(DTORequest.dateTimeStart),
                DatetimeEnd = DateTime.Parse(DTORequest.dateTimeEnd)
            }).GetAwaiter().GetResult();

            if (PAEntry != null)
            {
                // update all quests based on datas
                var quests = _questRepository.Get(user, _questTypeRepository, QuestState.InProgress ).GetAwaiter().GetResult();
                foreach (var quest in quests)
                {
                    var questHandler = QuestHandlers.Create(quest, user, _questTypeRepository);
                    questHandler.Update(PhysicalActivityQuestHandler.PHYSICAL_ACTIVTY_KEY, "1");
                    _questRepository.Update(quest).GetAwaiter().GetResult();
                }

                string PAEntryJson = JsonSerializer.Serialize(PAEntry);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(PAEntryJson).GetAwaiter().GetResult();
                return JsonSerializer.Deserialize<AddPAEntryDTOResponse>(PAEntryJson);
            }
            else
                context.Response.StatusCode = StatusCodes.Status204NoContent;
            return null;
        }
    }
}
