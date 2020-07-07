using LevelUpAPI.DataAccess.Quests;
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
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class AddQuestRequestHandler : RequestHandler<AddQuestDTORequest, AddQuestDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AddQuestRequestHandler(ClaimsPrincipal claims, AddQuestDTORequest dTORequest, ILogger logger, IUserRepository userRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository, ICategoryRepository categoryRepository) : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
            _categoryRepository = categoryRepository;
        }

        protected async override Task<(AddQuestDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);

            if (user == null)
                return (null, statusCode, err);

            Quest quest = await Quests.Create(DTORequest, user, _questTypeRepository, _categoryRepository);
            quest = await _questRepository.Insert(quest);

            if (quest == null)
                return (null, HttpStatusCode.NoContent, null);

            AddQuestDTOResponse dtoResponse = new AddQuestDTOResponse(quest.Id, quest.CategoryId, quest.TypeId, quest.ProgressValue, quest.ProgressCount, quest.UserId, quest.XpValue, quest.CreationDate, quest.ExpirationDate, quest.IsClaimed);

            return (dtoResponse, HttpStatusCode.OK, null);
        }
    }
}
