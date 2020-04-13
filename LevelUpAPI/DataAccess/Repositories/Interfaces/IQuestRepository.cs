using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IQuestRepository : IRepository<Model.Quests, Quest>
    {
        public Task<IEnumerable<Quest>> Get(Dbo.User user);
        public Task<IEnumerable<Quest>> Get(Dbo.User user, int categoryId);
    }
}
