using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.RequestHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OpenFoodFactsDatasController : ControllerBase
    {
        private readonly IOFFDataRepository _oFFDataRepository;
        private readonly IFoodEntryRepository _foodEntryRepository;

        public OpenFoodFactsDatasController(IOFFDataRepository oFFDataRepository, IFoodEntryRepository foodEntryRepository)
        {
            _oFFDataRepository = oFFDataRepository;
            _foodEntryRepository = foodEntryRepository;
        }

        [HttpGet]
        [Route("Get/{barcode}")]
        public void GetOpenFoodFactsData(string barcode)
        {
            GetOFFDataRequestHandler getOFFDataRequestHandler = new GetOFFDataRequestHandler(_oFFDataRepository, barcode);
            getOFFDataRequestHandler.Execute(HttpContext);
        }

        [HttpPost]
        [Route("Post/{user-id}/{off-data-id}")]
        public void AddFoodEntryForUser(string userid, string offdataid)
        {
            AddFoodEntryRequestHandler addFoodEntryRequestHandler = new AddFoodEntryRequestHandler(_foodEntryRepository, userid, offdataid);
            addFoodEntryRequestHandler.Execute(HttpContext);
        }
    }
}