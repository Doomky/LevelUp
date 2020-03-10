using IdentityModel.Client;
using IdentityServer4.Models;
using LevelUpAPI.DataAccess.Repositories;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Model;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpAPI
{
    public class SignUpRequestHandler : RequestHandler<SignUpRequest>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";
        public const string endpoint = "clientcredentials";

        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;

        public SignUpRequestHandler(IAvatarRepository avatarRepository, IUserRepository userRepository)
        {
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            if (!_userRepository.CanSignUp(Request).GetAwaiter().GetResult())
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                return;
            }
            else
            {
                Dbo.Avatar avatar = _avatarRepository.Create().GetAwaiter().GetResult();
                Dbo.User user = _userRepository.SignUp(Request, avatar.Id).GetAwaiter().GetResult();

                string fullAddress = $"{HTTP}{address}:{port}/{endpoint}";
                var client = new HttpClient();
                string jsonString = JsonSerializer.Serialize<ClientCredentialsRequest>(new ClientCredentialsRequest()
                {
                    Id = user.Id,
                    Login = user.Login,
                    PasswordHash = user.PasswordHash
                });

                HttpContent httpContent = new StringContent(jsonString);
                HttpResponseMessage httpResponse = client.PostAsync(fullAddress, httpContent).GetAwaiter().GetResult();
                context.Response.StatusCode = StatusCodes.Status200OK;
                return;
            }
        }
    }
}
