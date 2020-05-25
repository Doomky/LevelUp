using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class PhysicalActivitiesRepository : Repository<PhysicalActivites, PhysicalActivity>, IPhysicalActivitiesRepository
    {
        public PhysicalActivitiesRepository(levelupContext context, ILogger<PhysicalActivitiesRepository> logger, IMapper mapper)
            : base(context, context.PhysicalActivites, logger, mapper)
        {
        }

        public PhysicalActivity GetPhysicalActivity(string name)
        {
            var result = _context.PhysicalActivites.Where(x => x.Name == name).FirstOrDefault();
            return _mapper.Map<PhysicalActivity>(result);
        }
    }
}
