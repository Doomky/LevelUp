using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityServer;
using IdentityServer4.Models;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Model;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpIdentityServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientCredentialsController : ControllerBase
    {
        private readonly levelupContext _context;
        private readonly IUserRepository _userRepository;

        public ClientCredentialsController(levelupContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<object> Get()
        {
            string bodyStr = "";
            Stream body = HttpContext.Request.Body;
            using (StreamReader reader = new StreamReader(body))
            {
                bodyStr = await reader.ReadToEndAsync();
            }
            ClientCredentialsDTORequest clientCredentialsRequest = JsonSerializer.Deserialize<ClientCredentialsDTORequest>(bodyStr);
            return Ok();
        }
    }
}