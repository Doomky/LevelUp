using LevelUpAPI.Dbo;
using LevelUpAPI.Dbo.OpenFoodFacts;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IOFFDataRepository : IRepository<OpenFoodFactsDatas, OpenFoodFactsData>
    {
        public Task<(OpenFoodFactsData, ProductData)> InsertFromBarcode(string code);
        public Task<OpenFoodFactsData> GetByBarcode(string code);
        public Task<OpenFoodFactsData> GetById(int id);
    }
}
