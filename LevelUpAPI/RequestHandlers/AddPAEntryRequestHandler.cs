using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class AddPAEntryRequestHandler : RequestHandler<AddPAEntryRequest>
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

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            PhysicalActivity PA = _physicalActivitiesRepository.GetPhysicalActivity(Request.Name);
            if (PA == null)
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return;
            }

            PhysicalActivityEntry PAEntry = _physicalActivitiesEntryRepository.Insert(new PhysicalActivityEntry()
            {
                UserId = user.Id,
                PhysicalActivitiesId = PA.Id,
                DatetimeStart = Request.dateTimeStart,
                DatetimeEnd = Request.dateTimeEnd
            }).GetAwaiter().GetResult();

            if (PAEntry != null)
            {
                // update all quests based on datas
                var quests = _questRepository.Get(user, _questTypeRepository).GetAwaiter().GetResult();
                foreach (var quest in quests)
                {
                    var questHandler = QuestHandlers.Create(quest, _questTypeRepository);
                    questHandler.Update("PhyisicalActivity", "1");
                    _questRepository.Update(quest).GetAwaiter().GetResult();
                }

                string PAEntryJson = JsonSerializer.Serialize(PAEntry);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(PAEntryJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
