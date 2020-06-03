using AutoMapper;
using LevelUpAPI.DataAccess.OpenFoodFacts.Product;
using LevelUpAPI.DataAccess.OpenFoodFacts.Tools;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Dbo.OpenFoodFacts;
using LevelUpAPI.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class OFFDataRepository : Repository<OpenFoodFactsDatas, OpenFoodFactsData>, IOFFDataRepository
    {
        public OFFDataRepository(levelupContext context, ILogger<PhysicalActivitiesEntryRepository> logger, IMapper mapper)
            : base(context, context.OpenFoodFactsDatas, logger, mapper)
        {

        }

        public async Task<(OpenFoodFactsData, ProductData)> InsertFromBarcode(string code)
        {
            HttpClient httpClient = new HttpClient();
            ProductApi productApi = new ProductApi(Utils.BuildBaseUri(), ref httpClient);
            ProductData productData = await productApi.GetAsync(code);

            OpenFoodFactsData openFoodFactsData = new OpenFoodFactsData(productData);
            return (base.Insert(openFoodFactsData).GetAwaiter().GetResult(), productData);
        }

        public async Task<OpenFoodFactsData> GetByBarcode(string code)
        {
            IEnumerable<OpenFoodFactsData> openFoodFactsDatas = await base.Get();
            var query = from openFoodFactsData in openFoodFactsDatas
                        where openFoodFactsData.Code == code
                        select openFoodFactsData;
            if (query.Any())
            {
                return query.First();
            }
            return null;
        }

        public async Task<OpenFoodFactsData> GetById(int id)
        {
            IEnumerable<OpenFoodFactsData> openFoodFactsDatas = await base.Get();
            var query = from openFoodFactsData in openFoodFactsDatas
                        where openFoodFactsData.Id == id
                        select openFoodFactsData;
            if (query.Any())
            {
                return query.First();
            }
            return null;
        }
    }
}
