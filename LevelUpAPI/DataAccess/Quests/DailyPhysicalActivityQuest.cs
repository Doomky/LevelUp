using LevelUpAPI.Dbo;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.Dbo.QuestType;

namespace LevelUpAPI.DataAccess.Quests
{
    public static class DailyPhysicalActivityQuest
    {

        public static Quest Initialize(Quest quest, User user, QuestTypeAsEmum questTypeAsEmum, AddQuestRequest addQuestRequest)
        {
            quest.ProgressValue = 0;
            quest.ProgressCount = 1;

            return quest;
        }
    }
}
