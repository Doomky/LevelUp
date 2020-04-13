using AutoMapper;
using LevelUpAPI.DataAccess.OpenFoodFacts.Product;
using LevelUpAPI.DataAccess.OpenFoodFacts.Tools;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Dbo.OpenFoodFacts;
using LevelUpAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class OFFDatasCategoryRepository : Repository<OpenFoodFactsDatasCategories, OpenFoodFactsDatasCategory>, IOFFDatasCategoryRepository
    {
        protected readonly IOFFCategoryRepository _oFFCategoryRepository;
        protected readonly IOFFDataRepository _oFFDataRepository;

        public OFFDatasCategoryRepository(IOFFDataRepository oFFDataRepository, IOFFCategoryRepository oFFCategoryRepository, Model.levelupContext context, ILogger<OFFDatasCategoryRepository> logger, IMapper mapper) 
            : base(context, context.OpenFoodFactsDatasCategories, logger, mapper)
        {
            _oFFDataRepository = oFFDataRepository;
            _oFFCategoryRepository = oFFCategoryRepository;
        }

        public async Task<OpenFoodFactsDatasCategory> GetByCategoryName(string name)
        {
            var category = await _oFFCategoryRepository.GetByName(name);
            if (category != null)
            {
                var dataCategories = await base.Get();
                return dataCategories
                    .Where(datasCategory => datasCategory.CategoryId == category.Id)
                    .FirstOrDefault();
            }
            else
            {
                // we need to add the category
                category = new OpenFoodFactsCategory()
                {
                    Name = name
                };
                category = await _oFFCategoryRepository.Insert(category);
                if (category != null)
                {
                    OpenFoodFactsData openFoodFactsData = await _oFFDataRepository.InsertFromCategory(name);

                    if (openFoodFactsData != null)
                    {
                        OpenFoodFactsDatasCategory openFoodFactsDatasCategory = new OpenFoodFactsDatasCategory()
                        { 
                            CategoryId = category.Id,
                            DataId = openFoodFactsData.Id
                        };

                        return await base.Insert(openFoodFactsDatasCategory);
                    }
                }
            }
            return null;
        }
    }
}
