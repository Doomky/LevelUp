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
    public class UpdateAvatarRequestHandler : RequestHandler<UpdateAvatarDTORequest>
    {
        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;

        public UpdateAvatarRequestHandler(IUserRepository userRepository, IAvatarRepository avatarRepository)
        {
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            Avatar avatar = _avatarRepository.GetByUser(user).GetAwaiter().GetResult();

            if (avatar != null)
            {
                avatar.Size = Request.NewSize;
                avatar = _avatarRepository.Update(avatar).GetAwaiter().GetResult();
                if (avatar != null)
                {
                    string avatarJson = JsonSerializer.Serialize(avatar);
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.WriteAsync(avatarJson).GetAwaiter().GetResult();
                }
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
