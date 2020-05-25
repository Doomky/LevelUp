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
        private readonly IOFFCategoryRepository _oFFCategoryRepository;
        private readonly IOFFDataRepository _oFFDataRepository;

        public OpenFoodFactsDatasController(IOFFDatasCategoryRepository oFFDataCategoryRepository, IOFFCategoryRepository oFFCategoryRepository, IOFFDataRepository oFFDataRepository)
        {
            _oFFDataCategoryRepository = oFFDataCategoryRepository;
            _oFFCategoryRepository = oFFCategoryRepository;
            _oFFDataRepository = oFFDataRepository;
        }

        /// <summary>
        /// Get an OpenFoodFacts(OFF) product from a barcode. 
        /// </summary>
        /// <param name="barcode">The barcode the user want an OFF product for.</param>
        /// <response code="200">The OFF product exists.</response>
        /// <response code="204">The OFF product was not found for this barcode in the database.</response>
        /// <response code="400">The request is malformed.</response>
        [HttpGet]
        [Route("{barcode}")]
        public void GetOpenFoodFactsDataFromBarcode(string barcode)
        {
            GetOFFDataRequestHandler getOFFDataRequestHandler = new GetOFFDataRequestHandler(_oFFDataRepository, _oFFCategoryRepository, _oFFDataCategoryRepository, barcode);
            getOFFDataRequestHandler.Execute(HttpContext);
        }

        /// <summary>
        /// Get the first OpenFoodFacts(OFF) product of a category. 
        /// </summary>
        /// <param name="categoryName">The category name the user want the first OFF product for.</param>
        /// <response code="200">The category exists and an OFF product was found.</response>
        /// <response code="204">The category was not found in the database or the category is empty.</response>
        /// <response code="400">The request is malformed.</response>
        [HttpGet]
        [Route("category/{categoryName}")]
        public void GetOpenFoodFactsDataFromCategory(string categoryName)
        {
            GetOFFDataFromCategoryRequestHandler getOFFDataFromCategoryRequestHandler = new GetOFFDataFromCategoryRequestHandler(_oFFDataCategoryRepository, categoryName);
            getOFFDataFromCategoryRequestHandler.Execute(HttpContext);
        }
    }
}