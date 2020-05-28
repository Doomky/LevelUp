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
    public class PhysicalActivitiesRepository : Repository<PhysicalActivities, PhysicalActivity>, IPhysicalActivitiesRepository
    {
        public PhysicalActivitiesRepository(levelupContext context, ILogger<PhysicalActivitiesRepository> logger, IMapper mapper)
            : base(context, context.PhysicalActivities, logger, mapper)
        {
        }

        public PhysicalActivity GetPhysicalActivity(string name)
        {
            var result = _context.PhysicalActivities.Where(x => x.Name == name).FirstOrDefault();
            return _mapper.Map<PhysicalActivity>(result);
        }
    }
}
