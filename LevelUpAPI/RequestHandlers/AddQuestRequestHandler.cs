using LevelUpAPI.DataAccess.Quests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
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

        public AddQuestRequestHandler(IUserRepository userRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository, ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
            _categoryRepository = categoryRepository;
        }

        protected override async Task<AddQuestDTOResponse> ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(DTORequest, context, _userRepository);
            if (!isOk || user == null)
                return null;

            Quest quest = Quests.Create(DTORequest, user, _questTypeRepository, _categoryRepository).GetAwaiter().GetResult();

            quest = _questRepository.Insert(quest).GetAwaiter().GetResult();
            if (quest != null)
            {
                string questJson = JsonSerializer.Serialize(quest);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(questJson).GetAwaiter().GetResult();
                return JsonSerializer.Deserialize<AddQuestDTOResponse>(questJson);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return null;
            }
        }
    }
}
