using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class SelectSkinRequestHandler : RequestHandler<SelectSkinDTORequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAvatarRepository _avatarRepository;
        private readonly ISkinRepository _skinRepository;

        public SelectSkinRequestHandler(IUserRepository userRepository, IAvatarRepository avatarRepository, ISkinRepository skinRepository)
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

            Skin skin = _skinRepository.Get(Request.Id).GetAwaiter().GetResult().FirstOrDefault();

            if (skin != null)
            {
                Avatar avatar = _avatarRepository.GetByUser(user).GetAwaiter().GetResult();

                if (avatar != null && avatar.Level >= skin.LevelMin)
                {
                    avatar.SkinId = Request.Id;
                    avatar = _avatarRepository.Update(avatar).GetAwaiter().GetResult();
                    if (avatar != null)
                    {
                        string avatarJson = JsonSerializer.Serialize(avatar);
                        context.Response.StatusCode = StatusCodes.Status200OK;
                        context.Response.WriteAsync(avatarJson).GetAwaiter().GetResult();
                        return;
                    }
                }
            }
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
