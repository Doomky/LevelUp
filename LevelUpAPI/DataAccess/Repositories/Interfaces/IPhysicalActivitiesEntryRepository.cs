using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IPhysicalActivitiesEntryRepository : IRepository<PhysicalActivitesEntries, PhysicalActivityEntry>
    {
        public List<Dbo.PhysicalActivitiesEntries> GetPhysicalActivityEntries(string login);
        public List<Dbo.NbPhysicalActivitiesEntriesByLogin> GetTotalPhysicalActivitiesEntries(string login);
    }
}
