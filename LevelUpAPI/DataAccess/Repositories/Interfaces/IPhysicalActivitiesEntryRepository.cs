using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IPhysicalActivitiesEntryRepository : IRepository<PhysicalActivitiesEntries, PhysicalActivityEntry>
    {
        public Task<IEnumerable<PhysicalActivityEntry>> GetByLogin(string login);
        public Task<IEnumerable<NbPhysicalActivityEntryByLogin>> GetTotalByLogin(string login);
    }
}
