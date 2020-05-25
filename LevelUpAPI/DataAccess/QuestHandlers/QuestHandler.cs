using LevelUpAPI.DataAccess.QuestHandlers.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;

namespace LevelUpAPI.DataAccess.QuestHandlers
{
    public abstract class QuestHandler : IQuestHandler
    {
        public Quest Quest { get; set; }
        public abstract QuestState Update(UpdateQuestRequest updateQuestRequest);

        public abstract QuestState Update(string key, string value);

        public abstract QuestState GetState();
    }
}
