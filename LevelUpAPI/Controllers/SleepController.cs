using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SleepController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public SleepController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all sleep entires.
        /// </summary>
        /// <remarks>
        /// The body of the response will contains a list with those fields:
        /// 
        ///     {
        ///         "Id"
        ///         "Name"
        ///         "Description"
        ///         "StartTimeMillis"
        ///         "EndTimeMillis"
        ///         "ModifiedTimeMillis"
        ///         "Application"
        ///         "ActivityType"
        ///         "ActiveTimeMillis"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Sleep entries have been returned.</response>
        /// <response code="400">The request is malformed.</response>
        [HttpGet]
        public void Get()
        {
            GetSleepEntriesRequestHandler getSleepEntriesRequestHandler = new GetSleepEntriesRequestHandler(_userRepository);
            getSleepEntriesRequestHandler.Execute(HttpContext);
        }
    }
}