using IdentityModel.Client;
using IdentityServer4.Models;
using LevelUpAPI.Model;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
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

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            using (var dbcontext = new levelupContext())
            {
                var query = from users in dbcontext.Users
                            where users.Login == Request.Login || users.Email == Request.EmailAddress
                            select users;

                if (query.Any())
                {
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    return;
                }
                else
                {
                    Avatars avatar = new Avatars()
                    {
                        Level = 1,
                        Size = 1,
                        Xp = 0,
                        XpMax = 10,
                    };
                    dbcontext.Avatars.Add(avatar);
                    dbcontext.SaveChanges();


                    Users user = new Users()
                    {
                        Login = Request.Login,
                        Firstname = Request.Firstname,
                        Lastname = Request.Lastname,
                        Email = Request.EmailAddress,
                        PasswordHash = Request.PasswordHash.Sha256(),
                        LastLoginDate = null,
                        AvatarId = avatar.Id
                    };
                    dbcontext.Users.Add(user);
                    dbcontext.SaveChanges();

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
}
