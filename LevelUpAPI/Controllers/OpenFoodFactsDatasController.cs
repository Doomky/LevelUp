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
    public class OpenFoodFactsDatasController : ControllerBase
    {
        private readonly IOFFDataRepository _oFFDataRepository;

        public OpenFoodFactsDatasController(IOFFDataRepository oFFDataRepository)
        {
            _oFFDataRepository = oFFDataRepository;
        }

        [HttpGet]
        [Route("{barcode}")]
        public void GetOpenFoodFactsData(string barcode)
        {
            GetOFFDataRequestHandler getOFFDataRequestHandler = new GetOFFDataRequestHandler(_oFFDataRepository, barcode);
            getOFFDataRequestHandler.Execute(HttpContext);
        }
    }
}