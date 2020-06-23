using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IQuestTypeRepository: IRepository<QuestsTypes, Dbo.QuestType>
    {
        public IEnumerable<Dbo.QuestType> GetAllQuestTypes();
        public Task<Dbo.QuestType.QuestTypeAsEmum> GetAsEmum(int id);
    }
}
