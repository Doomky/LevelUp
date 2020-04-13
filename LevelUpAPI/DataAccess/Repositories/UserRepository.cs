using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using LevelUpRequests;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using IdentityModel.Client;
using System.Collections.Generic;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class UserRepository : Repository<Users, User>, IUserRepository
    {
        public UserRepository(levelupContext context, ILogger<UserRepository> logger, IMapper mapper) : base(context, context.Users, logger, mapper)
        {

        }

        private async Task<User> RefreshUserAccessToken(User user)
        {
            var values = new Dictionary<string, string>
            {
                { "client_id", "498756810683-agbruikv9b2j9hjs59rrbpb6j13l0l41.apps.googleusercontent.com" },
                { "client_secret", "9QrjOKzI4ldnqXx_uqcrbOK0" },
                { "grant_type", "refresh_token" },
                { "refresh_token", user.GoogleRefreshToken.ToString() }
            };
            var httpClient = new HttpClient();
            var content = new FormUrlEncodedContent(values);
            HttpResponseMessage httpResponse = httpClient.PostAsync("https://oauth2.googleapis.com/token", content)
                                                         .GetAwaiter()
                                                         .GetResult();
            var response = httpResponse.Content.ReadAsStringAsync()
                                               .GetAwaiter()
                                               .GetResult();
            if (httpResponse.IsSuccessStatusCode)
            {
                JObject tokenAsJson = JObject.Parse(response);
                user.GoogleAccessToken = tokenAsJson.TryGetString("access_token");
                int expires_in = (int)tokenAsJson.TryGetInt("expires_in");
                user.GoogleAccessExpiration = DateTime.Now.AddSeconds(expires_in);
                user = await Update(user);
                return user;
            }
            return user;
        }
        private async Task<User> CheckGoogleAccessValidityAsync(User user)
        {
            if (user.GoogleRefreshToken == null
                || (user.GoogleAccessToken != null && user.GoogleAccessExpiration > DateTime.Now))
                return user;
            return await RefreshUserAccessToken(user);
        }

        public async Task<User> GetUserById(int id)
        {
            var arr = await base.Get(id);
            if (arr.Any())
            {
                User user = arr.First();
                user = await CheckGoogleAccessValidityAsync(user);
                if (user == null) return arr.First();
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CanSignUp(SignUpRequest signUpRequest)
        {
            var arr = await base.Get();
            var query = from user in arr
                        where user.Login == signUpRequest.Login || user.Email == signUpRequest.EmailAddress
                        select user;

            return !query.Any();
        }

        public async Task<User> SignUp(SignUpRequest signUpRequest, int avatarId)
        {
            User user = new User()
            {
                Login = signUpRequest.Login,
                Firstname = signUpRequest.Firstname,
                Lastname = signUpRequest.Lastname,
                Email = signUpRequest.EmailAddress,
                PasswordHash = signUpRequest.PasswordHash,
                LastLoginDate = null,
                AvatarId = avatarId
            };
            return await Insert(user);
        }

        public async Task<bool> CanSignIn(SignInRequest signInRequest)
        {
            var arr = await base.Get();
            var query = from users in arr
                        where users.Login == signInRequest.Login || users.Email == signInRequest.EmailAddress
                        select users;
            return query.Any();
        }

        public async Task<User> GetUserByLoginOrEmail(string login = null, string email = null)
        {
            var arr = await base.Get();
            var query = from users in arr
                        where (login != null && users.Login == login) || (email != null && users.Email == email)
                        select users;
            if (query.Any())
            {
                User user = query.First();
                user = await CheckGoogleAccessValidityAsync(user);
                if (user == null) return query.First();
                return user;
            }
            return null;
        }

        public async Task<User> GetUserByClaims(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                return null;
            foreach (var claim in claimsPrincipal.Claims)
                if (claim.Type == "client_id")
                    return await GetUserByLoginOrEmail(claim.Value);
            return null;
        }
    }
}
