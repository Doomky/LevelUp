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
using static LevelUpAPI.Helpers.ClaimsHelpers;
using static LevelUpDTO.GetQuestByCategoryDTOResponse;

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestByCategoryRequestHandler : RequestHandler<GetQuestByCategoryDTORequest, GetQuestByCategoryDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly string _categoryName;

        public GetQuestByCategoryRequestHandler(ClaimsPrincipal claims, GetQuestByCategoryDTORequest dTORequest, ILogger logger, IUserRepository userRepository, IQuestRepository questRepository, ICategoryRepository categoryRepository, IQuestTypeRepository questTypeRepository, string categoryName) : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _categoryRepository = categoryRepository;
            _questTypeRepository = questTypeRepository;
            _categoryName = categoryName;
        }

        protected async override Task<(GetQuestByCategoryDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            Category category = await _categoryRepository.GetByName(_categoryName);

            if (category == null)
                return (null, HttpStatusCode.BadRequest, "the category does not exit");
            
            IEnumerable<Quest> quests = await _questRepository.Get(user, category.Id, _questTypeRepository, null);

            List<QuestDTOResponse> questsDTOs = quests.Select(quest => new QuestDTOResponse(
                quest.Id,
                quest.CategoryId,
                quest.TypeId,
                quest.ProgressValue,
                quest.ProgressCount,
                quest.UserId,
                quest.XpValue,
                quest.CreationDate,
                quest.ExpirationDate,
                quest.IsClaimed
            )).ToList();

            GetQuestByCategoryDTOResponse dtoReponse = new GetQuestByCategoryDTOResponse(questsDTOs);

            return (dtoReponse, HttpStatusCode.OK, null);
        }
    }
}
