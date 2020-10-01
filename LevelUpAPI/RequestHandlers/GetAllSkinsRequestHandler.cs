using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.DataAccess.SkinHandlers;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using LevelUpDTO.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class GetAllSkinsRequestHandler : RequestHandler<GetAllSkinsDTORequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAvatarRepository _avatarRepository;
        private readonly ISkinRepository _skinRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;

        public GetAllSkinsRequestHandler(IUserRepository userRepository, IAvatarRepository avatarRepository, ISkinRepository skinRepository, ICategoryRepository categoryRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository)
        {
            _userRepository = userRepository;
            _avatarRepository = avatarRepository;
            _skinRepository = skinRepository;
            _categoryRepository = categoryRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            IEnumerable<Skin> skins = _skinRepository.GetAll().GetAwaiter().GetResult();
            IEnumerable<GetAvailableSkinsDTOResponse> skinsDTOReponse = skins.Select(skin =>
            {
                SkinInformations skinInformations = SkinHandlers.Handle(user, skin, _avatarRepository, _categoryRepository, _questTypeRepository, _questRepository).GetAwaiter().GetResult();
                return new GetAvailableSkinsDTOResponse(skin.Id, skin.Name, skin.LevelMin, skinInformations.Description, skinInformations.Unlocked);
            });

            if (skinsDTOReponse != null)
            {
                string skinsJson = JsonSerializer.Serialize(skinsDTOReponse);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(skinsJson).GetAwaiter().GetResult();
                return;
            }
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
