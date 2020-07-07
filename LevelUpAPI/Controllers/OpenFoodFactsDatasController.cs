using System;
using System.Net;
using System.Threading.Tasks;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Helpers;
using LevelUpAPI.RequestHandlers;
using LevelUpDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LevelUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OpenFoodFactsDatasController : ControllerBase
    {
        private readonly ILogger<OpenFoodFactsDatasController> _logger;
        private readonly IOFFDatasCategoryRepository _oFFDataCategoryRepository;
        private readonly IOFFCategoryRepository _oFFCategoryRepository;
        private readonly IOFFDataRepository _oFFDataRepository;

        public OpenFoodFactsDatasController(ILogger<OpenFoodFactsDatasController> logger, IOFFDatasCategoryRepository oFFDataCategoryRepository, IOFFCategoryRepository oFFCategoryRepository, IOFFDataRepository oFFDataRepository)
        {
            _logger = logger;
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
        public async Task<ActionResult<GetOFFDataDTOResponse>> GetOpenFoodFactsDataFromBarcode([FromRoute] string barcode)
        {
            GetOFFDataDTORequest dtoRequest = new GetOFFDataDTORequest();
            dtoRequest.Barcode = barcode;
            GetOFFDataRequestHandler getOFFDataRequestHandler = new GetOFFDataRequestHandler(User, dtoRequest, _logger,  _oFFDataRepository, _oFFCategoryRepository, _oFFDataCategoryRepository, barcode);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getOFFDataRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
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
        public async Task<ActionResult<GetOFFDataFromCategoryDTOResponse>> GetOpenFoodFactsDataFromCategory([FromRoute] string categoryName)
        {
            GetOFFDataFromCategoryDTORequest dtoRequest = new GetOFFDataFromCategoryDTORequest();
            dtoRequest.Category = categoryName;
            GetOFFDataFromCategoryRequestHandler getOFFDataFromCategoryRequestHandler = new GetOFFDataFromCategoryRequestHandler(User, dtoRequest, _logger, _oFFDataCategoryRepository, categoryName);
            (var dtoResponse, HttpStatusCode statusCode, string err) = await getOFFDataFromCategoryRequestHandler.Handle();
            return ActionResultHelpers.FromHttpStatusCode(statusCode, dtoResponse);
        }
    }
}