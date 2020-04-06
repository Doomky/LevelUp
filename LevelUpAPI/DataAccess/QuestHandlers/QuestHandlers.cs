using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.Dbo.QuestType;

namespace LevelUpAPI.DataAccess.QuestHandlers
{
    public static class QuestHandlers
    {
        public static QuestHandler Create(Quest quest, IQuestTypeRepository questTypeRepository)
        {
            QuestHandler questHandler = null;
            switch (questTypeRepository.GetAsEmum(quest.TypeId).GetAwaiter().GetResult())
            {
                case QuestTypeAsEmum.CaloriesGoal:
                    questHandler = new CaloriesGoalQuestHandler();
                    break;
                case QuestTypeAsEmum.Undefined:
                default:
                    break;
            }
            questHandler.Quest = quest;
            return questHandler;
        }
    }
}
