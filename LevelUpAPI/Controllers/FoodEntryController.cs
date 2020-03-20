using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FoodEntryController : ControllerBase
    {
        private readonly IFoodEntryRepository _foodEntryRepository;

        public FoodEntryController(IFoodEntryRepository foodEntryRepository)
        {
            _foodEntryRepository = foodEntryRepository;
        }

        [HttpPost]
        [Route("add")]
        public void AddFoodEntry()
        {
            AddFoodEntryRequestHandler addFoodEntryRequestHandler = new AddFoodEntryRequestHandler(_foodEntryRepository);
            addFoodEntryRequestHandler.Execute(HttpContext);
        }
    }
}
