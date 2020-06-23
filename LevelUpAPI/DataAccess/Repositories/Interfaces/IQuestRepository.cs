using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestState = LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler.QuestState;


namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IQuestRepository : IRepository<Model.Quests, Quest>
    {
        public Task<IEnumerable<Quest>> Get(User user, IQuestTypeRepository questTypeRepository, QuestState? questState);
        public Task<Quest> GetById(User user, int questId);

        public Task<Quest> SetIsClaimedById(User user, int questId);

        public Task<IEnumerable<Quest>> Get(User user, int categoryId, IQuestTypeRepository questTypeRepository, QuestState? questState);
    }
}
