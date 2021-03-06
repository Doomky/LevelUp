﻿using LevelUpAPI.DataAccess.Repositories.Interfaces;
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
    public class GetAvatarInfoRequestHandler : RequestHandler<GetAvatarInfoDTORequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAvatarRepository _avatarRepository;

        public GetAvatarInfoRequestHandler(IUserRepository userRepository, IAvatarRepository avatarRepository)
        {
            _userRepository = userRepository;
            _avatarRepository = avatarRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            Avatar avatar = _avatarRepository.GetByUser(user).GetAwaiter().GetResult();

            if (avatar != null)
            {
                string avatarJson = JsonSerializer.Serialize(avatar);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(avatarJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
