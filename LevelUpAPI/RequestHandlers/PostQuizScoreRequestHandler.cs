using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO.Requests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LevelUpAPI.RequestHandlers
{
    public class PostQuizScoreRequestHandler : RequestHandler<PostQuizScoreDTORequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAvatarRepository _avatarRepository;

        public PostQuizScoreRequestHandler(IUserRepository userRepository, IAvatarRepository avatarRepository)
        {
            _userRepository = userRepository;
            _avatarRepository = avatarRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            User user = _userRepository.GetUserByLoginOrEmail(Request.Login).GetAwaiter().GetResult();
            if (user == null)
                return;

            Avatar avatar = _avatarRepository.AddXp(user, Request.Score/100).GetAwaiter().GetResult();
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
