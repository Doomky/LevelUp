using System;
using LevelUpAPI.Dbo;
using LevelUpDTO;

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
        public QuestState Update(UpdateQuestDTORequest updateQuestRequest);

        public QuestState GetState();
    }
}
