using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IFoodEntryRepository : IRepository<FoodEntries, FoodEntry>
    {
        public List<Dbo.NbFoodEntriesByLogin> GetNbFoodEntries(string login);
    }
}
