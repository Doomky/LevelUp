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
        public Task<IEnumerable<Quest>> Get(User user);
        public Task<Quest> GetById(User user, int questId);
        public Task<IEnumerable<Quest>> Get(User user, int categoryId);
    }
}
