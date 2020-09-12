using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class GetAvailableSkinsRequestHandler : RequestHandler<GetAvailableSkinsDTORequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAvatarRepository _avatarRepository;
        private readonly ISkinRepository _skinRepository;

        public GetAvailableSkinsRequestHandler(IUserRepository userRepository, IAvatarRepository avatarRepository, ISkinRepository skinRepository)
        {
            _userRepository = userRepository;
            _avatarRepository = avatarRepository;
            _skinRepository = skinRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            Avatar avatar = _avatarRepository.GetByUser(user).GetAwaiter().GetResult();
            if (avatar != null)
            {
                IEnumerable<Skin> skins = _skinRepository.GetEquipable(user.Gender, avatar.Level).GetAwaiter().GetResult();
                if (skins != null)
                {
                    string skinsJson = JsonSerializer.Serialize(skins);
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.WriteAsync(skinsJson).GetAwaiter().GetResult();
                    return;
                }
            }
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
