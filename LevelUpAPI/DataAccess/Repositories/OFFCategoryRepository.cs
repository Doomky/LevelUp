using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class OFFCategoryRepository : Repository<OpenFoodFactsCategories, OpenFoodFactsCategory>, IOFFCategoryRepository
    {
        public OFFCategoryRepository(levelupContext context, ILogger<OFFCategoryRepository> logger, IMapper mapper) : base(context, context.OpenFoodFactsCategories, logger, mapper)
        {

        }

        public async Task<OpenFoodFactsCategory> GetByName(string name)
        {
            var categories = await base.Get();
            return categories
                .Where(category => category.Name == name)
                .FirstOrDefault();
        }
    }
}
