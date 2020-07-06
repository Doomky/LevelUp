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
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Net;

namespace LevelUpAPI.RequestHandlers
{
    public class AddPAEntryRequestHandler : RequestHandler<AddPAEntryDTORequest, AddPAEntryDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly IQuestRepository _questRepository;

        public AddPAEntryRequestHandler(ClaimsPrincipal claims, AddPAEntryDTORequest dtoRequest, ILogger logger, IUserRepository userRepository, IPhysicalActivitiesRepository physicalActivitiesRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository, IQuestTypeRepository questTypeRepository, IQuestRepository questRepository) : base(claims, dtoRequest, logger)
        {
            _userRepository = userRepository;
            _physicalActivitiesRepository = physicalActivitiesRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
            _questTypeRepository = questTypeRepository;
            _questRepository = questRepository;
        }

        protected async override Task<(AddPAEntryDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            PhysicalActivity PA = _physicalActivitiesRepository.GetPhysicalActivity(DTORequest.Name);

            if (PA == null)
                return (null, HttpStatusCode.NoContent, null);

            PhysicalActivityEntry PAEntry = await _physicalActivitiesEntryRepository.Insert(new PhysicalActivityEntry()
            {
                UserId = user.Id,
                PhysicalActivitiesId = PA.Id,
                DatetimeStart = DateTime.Parse(DTORequest.dateTimeStart),
                DatetimeEnd = DateTime.Parse(DTORequest.dateTimeEnd)
            });

            if (PAEntry == null)
                return (null, HttpStatusCode.NoContent, null);

            // update all quests based on datas
            var quests = await _questRepository.Get(user, _questTypeRepository, QuestState.InProgress);
            foreach (var quest in quests)
            {
                var questHandler = QuestHandlers.Create(quest, user, _questTypeRepository);
                questHandler.Update(PhysicalActivityQuestHandler.PHYSICAL_ACTIVTY_KEY, "1");
                await _questRepository.Update(quest);
            }

            return (new AddPAEntryDTOResponse(PAEntry.Id, PAEntry.UserId, PAEntry.PhysicalActivitiesId, PAEntry.DatetimeStart, PAEntry.DatetimeEnd), HttpStatusCode.OK, null);
        }
    }
}
