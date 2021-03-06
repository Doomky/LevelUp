﻿using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.Helpers;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Categories,  Dbo.Category>, ICategoryRepository
    {
        public CategoryRepository(levelupContext context, ILogger<CategoryRepository> logger, IMapper mapper) : base(context, context.Categories, logger, mapper)
        {
        }

        public IEnumerable<Dbo.Category> GetAllCategories()
        {
            var categories = _context.Categories.AsEnumerable();
            return _mapper.Map<IEnumerable<Dbo.Category>>(categories);
        }

        public async Task<Dbo.Category.CategoryAsEnum> GetAsEnum(int id)
        {
            Dbo.Category category = (await base.Get(id)).FirstOrDefault();
            if (category != null)
                return DataAccess.Category.AsEnum(category);
            return Dbo.Category.CategoryAsEnum.Undefined;
        }

        public async Task<Dbo.Category> GetByName(string name)
        {
            try
            {
                name = name.AsCategoryEnum().ToString();
                List<Categories> query = null;
                query = await _set.AsNoTracking().ToListAsync();
                var arr = _mapper.Map<Dbo.Category[]>(query);
                return arr
                    .Where(category => category.Name == name)
                    .First();
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get this entry", ex);
                return null;
            }
        }
    }
}
