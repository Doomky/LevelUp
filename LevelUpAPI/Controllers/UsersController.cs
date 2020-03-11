using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LevelUpAPI.Helpers;
using LevelUpAPI.Model;
using LevelUpAPI.Dbo;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Authorization;

namespace LevelUpAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly levelupContext _context;
        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;

        public UsersController(ILogger<UsersController> logger, levelupContext context, IAvatarRepository avatarRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _context = context;
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("signin")]
        public void SignIn()
        {
            SignInRequestHandler SignInHandler = new SignInRequestHandler(_userRepository);
            SignInHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("signup")]
        public void SignUp()
        {
            SignUpRequestHandler signUpRequestHandler = new SignUpRequestHandler(_avatarRepository, _userRepository);
            signUpRequestHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("change-password")]
        public void ChangePassword()
        {
            ChangePasswordRequestHandler changePasswordRequestHandler = new ChangePasswordRequestHandler(_userRepository);
            changePasswordRequestHandler.Execute(HttpContext);
        }
    }
}
