using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IPhysicalActivitiesRepository : IRepository<PhysicalActivites, PhysicalActivity>
    {
        public PhysicalActivity GetPhysicalActivity(string name);
    }
}
