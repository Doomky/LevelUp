using LevelUpAPI.Dbo;
using LevelUpRequests;
using System;
using System.Collections.Generic;

namespace LevelUpAPI.DataAccess.QuestHandlers.Interfaces
{
    public interface IQuestHandler
    {
        public enum QuestState
        {
            InProgress,
            Failed,
            Finished,
            Claimed
        }

        public Quest Quest { get; set; }
        public QuestState Update(UpdateQuestRequest updateQuestRequest);

        public QuestState GetState();
    }
}
