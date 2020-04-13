using System;
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

        /// <summary>
        /// Get an OpenFoodFacts(OFF) product from a barcode. 
        /// </summary>
        /// <response code="200">The OFF product exists.</response>
        /// <response code="204">The OFF product was not found for this barcode in the database.</response>
        [HttpGet]
        [Route("{barcode}")]
        public void GetOpenFoodFactsDataFromBarcode(string barcode)
        {
            GetOFFDataRequestHandler getOFFDataRequestHandler = new GetOFFDataRequestHandler(_oFFDataRepository, barcode);
            getOFFDataRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Get the first OpenFoodFacts(OFF) product of a category. 
        /// </summary>
        /// <response code="200">The category exists and an OFF product was found.</response>
        /// <response code="204">The category was not found in the database or the category is empty.</response>
        [HttpGet]
        [Route("category/{categoryName}")]
        public void GetOpenFoodFactsDataFromCategory(string categoryName)
        {
            GetOFFDataFromCategoryRequestHandler getOFFDataFromCategoryRequestHandler = new GetOFFDataFromCategoryRequestHandler(_oFFDataCategoryRepository, categoryName);
            getOFFDataFromCategoryRequestHandler.Execute(HttpContext);
        }
    }
}