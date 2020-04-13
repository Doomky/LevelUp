using LevelUpAPI.DataAccess.QuestHandlers.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.QuestHandlers
{
    public abstract class QuestHandler : IQuestHandler
    {
        public Quest Quest { get; set; }
        public abstract IQuestHandler.UpdateResult Update(UpdateQuestRequest updateQuestRequest);
    }
}
