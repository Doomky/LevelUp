using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Categories, Dbo.Category>
    {

        public IEnumerable<Dbo.Category> GetAllCategories();
        public Task<Dbo.Category.CategoryAsEnum> GetAsEnum(int id);

        public Task<Dbo.Category> GetByName(string name);
    }
}
