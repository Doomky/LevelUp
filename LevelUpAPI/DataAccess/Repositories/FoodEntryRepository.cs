using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Model;
using LevelUpAPI.Dbo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class FoodEntryRepository : Repository<FoodEntries, FoodEntry>, IFoodEntryRepository
    {
        public FoodEntryRepository(levelupContext context, ILogger<FoodEntryRepository> logger, IMapper mapper) : base(context, context.FoodEntries, logger, mapper)
        {
        }

        public async Task<IEnumerable<FoodEntry>> GetFromUser(string login)
        {
            try
            {
                List<FoodEntries> query = null;
                query = await _set
                        .Where( foodEntry => foodEntry.User.Login == login)
                        .AsNoTracking()
                        .ToListAsync();
                var arr = _mapper.Map<List<FoodEntry>>(query);
                return arr;
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get this entry", ex);
                return null;
            }
        }

        public FoodEntry GetFoodEntryById(int Id)
        {
            var result = _context.FoodEntries.Where(x => x.Id == Id).FirstOrDefault();
            return _mapper.Map<FoodEntry>(result);
        }

        public List<Dbo.NbFoodEntryByLogin> GetNbFoodEntries(string login)
        {
            var result = _context.NbFoodEntriesByLogin.Where(x => x.Login == login).ToList();
            return _mapper.Map<List<Dbo.NbFoodEntryByLogin>>(result);
        }
    }
}
