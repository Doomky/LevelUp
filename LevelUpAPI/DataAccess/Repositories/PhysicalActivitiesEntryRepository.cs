using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class PhysicalActivitiesEntryRepository : Repository<PhysicalActivitiesEntries, PhysicalActivityEntry>, IPhysicalActivitiesEntryRepository
    {
        public PhysicalActivitiesEntryRepository(levelupContext context, ILogger<PhysicalActivitiesEntryRepository> logger, IMapper mapper)
            : base(context, context.PhysicalActivitiesEntries, logger, mapper)
        {
        }

        public async Task<IEnumerable<PhysicalActivityEntry>> GetByLogin(string login)
        {
            var result = await (from physicalActivity in _context.PhysicalActivitiesEntries.AsNoTracking()
                            join user in _context.Users.AsNoTracking() on physicalActivity.UserId equals user.Id
                            where user.Login == login
                            select physicalActivity).ToListAsync();

            return _mapper.Map<List<PhysicalActivityEntry>>(result);
        }

        public async Task<IEnumerable<NbPhysicalActivityEntryByLogin>> GetTotalByLogin(string login)
        {
            var result = await _context.NbPhysicalActivitiesEntriesByLogin
                .Where(x => x.Login == login)
                .ToListAsync();
            return _mapper.Map<List<NbPhysicalActivityEntryByLogin>>(result);
        }
    }
}
