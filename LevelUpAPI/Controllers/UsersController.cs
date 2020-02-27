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

namespace LevelUpAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public object Get()
        {
            int id = -1;
            Users user = null;
            
            using (Stream receiveStream = HttpContext.Request.Body)
            {
                JObject body = null;
                using (StreamReader streamReader = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    string bodyAsStr = streamReader.ReadToEndAsync().Result;
                    if (bodyAsStr != null)
                    {
                        try
                        {
                            body = JObject.Parse(bodyAsStr);
                        }
                        catch (Exception)
                        {
                            body = null;
                        }
                    }
                }
                if (body != null && body.ContainsKey("id"))
                {
                    id = body.Value<int>("id");
                    user = DataAccess.User.GetUserById(id);
                }
            }
            _logger.LogInformation(RequestMessageFormatterHelpers.ToLoggerMessage(HttpContext));
            return user;
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
