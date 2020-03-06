using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.Helpers;
using LevelUpAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using Newtonsoft.Json.Linq;
using LevelUpAPI.DataAccess.Repositories;
using LevelUpAPI.Dbo;
using LevelUpRequests;

namespace LevelUpAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly levelupContext _context;

        public UsersController(ILogger<UsersController> logger, levelupContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Route("signin")]
        public void SignIn()
        {
            SignInRequestHandler SignInHandler = new SignInRequestHandler();
            SignInHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("signup")]
        public void SignUp()
        {
            SignUpRequestHandler signUpRequestHandler = new SignUpRequestHandler();
            signUpRequestHandler.Execute(HttpContext);
        }

    }
}
