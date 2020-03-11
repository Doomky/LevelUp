using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class PhysicalActivitiesEntryRepository : Repository<PhysicalActivitesEntries, PhysicalActivityEntry>, IPhysicalActivitiesEntryRepository
    {
        public PhysicalActivitiesEntryRepository(levelupContext context, ILogger<PhysicalActivitiesEntryRepository> logger, IMapper mapper)
            : base(context, context.PhysicalActivitesEntries, logger, mapper)
        {
        }

        public List<Dbo.NbPhysicalActivitiesEntriesByLogin> GetNbPhysicalActivitiesEntries(string login)
        {
            var result = _context.NbPhysicalActivitiesEntriesByLogin.Where(x => x.Login == login);
            return _mapper.Map<List<Dbo.NbPhysicalActivitiesEntriesByLogin>>(result);
        }
    }
}
