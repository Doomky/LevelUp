using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Model;
using LevelUpAPI.Dbo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class FoodEntryRepository : Repository<FoodEntries, FoodEntry>, IFoodEntryRepository
    {
        public FoodEntryRepository(levelupContext context, ILogger<FoodEntryRepository> logger, IMapper mapper) : base(context, context.FoodEntries, logger, mapper)
        {
        }

        public FoodEntry GetFoodEntryById(int Id)
        {
            var result = _context.FoodEntries.Where(x => x.Id == Id).FirstOrDefault();
            return _mapper.Map<FoodEntry>(result);
        }

        public List<Dbo.NbFoodEntriesByLogin> GetNbFoodEntries(string login)
        {
            var result = _context.NbFoodEntriesByLogin.Where(x => x.Login == login).ToList();
            return _mapper.Map<List<Dbo.NbFoodEntriesByLogin>>(result);
        }
    }
}
