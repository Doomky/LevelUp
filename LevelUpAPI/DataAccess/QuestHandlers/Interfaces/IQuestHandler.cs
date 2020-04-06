using LevelUpAPI.Dbo;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.QuestHandlers.Interfaces
{
    public interface IQuestHandler
    {
        public enum UpdateResult
        {
            InProgress,
            Failed,
            Finished
        }

        public Quest Quest { get; set; }
        public UpdateResult Update(UpdateQuestRequest updateQuestRequest);
    }
}
