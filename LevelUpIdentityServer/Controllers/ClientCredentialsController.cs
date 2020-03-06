using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityServer;
using IdentityServer4.Models;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpIdentityServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientCredentialsController : ControllerBase
    {
        [HttpPost]
        public async Task<object> Get()
        {
            string bodyStr = "";
            Stream body = HttpContext.Request.Body;
            using (StreamReader reader = new StreamReader(body))
            {
                bodyStr = await reader.ReadToEndAsync();
            }
            ClientCredentialsRequest clientCredentialsRequest = JsonSerializer.Deserialize<ClientCredentialsRequest>(bodyStr);
            Config._clients.Add(clientCredentialsRequest.Id, new Client()
            {
                ClientId = clientCredentialsRequest.Login,
                ClientSecrets = 
                {
                    new Secret(clientCredentialsRequest.PasswordHash)
                },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = 
                { 
                    "api1" 
                }
            });
            return Ok();
        }
    }
}