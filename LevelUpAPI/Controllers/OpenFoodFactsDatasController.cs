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
        private readonly IOFFDatasCategoryRepository _oFFDataCategoryRepository;
        private readonly IOFFDataRepository _oFFDataRepository;

        public OpenFoodFactsDatasController(IOFFDatasCategoryRepository oFFDataCategoryRepository, IOFFDataRepository oFFDataRepository)
        {
            _oFFDataCategoryRepository = oFFDataCategoryRepository;
            _oFFDataRepository = oFFDataRepository;
        }

        [HttpGet]
        [Route("{barcode}")]
        public void GetOpenFoodFactsDataFromBarcode(string barcode)
        {
            GetOFFDataRequestHandler getOFFDataRequestHandler = new GetOFFDataRequestHandler(_oFFDataRepository, barcode);
            getOFFDataRequestHandler.Execute(HttpContext);
        }

        [HttpGet]
        [Route("category/{categoryName}")]
        public void GetOpenFoodFactsDataFromCategory(string categoryName)
        {
            GetOFFDataFromCategoryRequestHandler getOFFDataFromCategoryRequestHandler = new GetOFFDataFromCategoryRequestHandler(_oFFDataCategoryRepository, categoryName);
            getOFFDataFromCategoryRequestHandler.Execute(HttpContext);
        }
    }
}