using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class RemoveQuestRequestHandler : RequestHandler<RemoveQuestDTORequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;

        public RemoveQuestRequestHandler(IUserRepository userRepository, IQuestRepository questRepository)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            _questRepository.Delete(Request.QuestId).GetAwaiter().GetResult();
            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
