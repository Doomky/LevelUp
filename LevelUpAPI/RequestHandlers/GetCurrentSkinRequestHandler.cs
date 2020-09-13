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
    public class GetCurrentSkinRequestHandler : RequestHandler<GetCurrentSkinDTORequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISkinRepository _skinRepository;

        public GetCurrentSkinRequestHandler(IUserRepository userRepository, ISkinRepository skinRepository)
        {
            _userRepository = userRepository;
            _skinRepository = skinRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            Skin skin = _skinRepository.GetByUser(user).GetAwaiter().GetResult();

            if (skin != null)
            {
                string skinJson = JsonSerializer.Serialize(skin);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(skinJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
