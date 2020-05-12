using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IPhysicalActivitiesEntryRepository
    {
        public List<Dbo.NbPhysicalActivitiesEntriesByLogin> GetNbPhysicalActivitiesEntries(string login);
    }
}
