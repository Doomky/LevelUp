using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IPhysicalActivitiesRepository : IRepository<PhysicalActivities, PhysicalActivity>
    {
        public IEnumerable<PhysicalActivity> GetAllPhysicalActivities();
        public PhysicalActivity GetPhysicalActivity(string name);
    }
}
