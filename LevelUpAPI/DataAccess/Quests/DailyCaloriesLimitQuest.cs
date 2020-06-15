using LevelUpAPI.Dbo;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.Dbo.QuestType;

namespace LevelUpAPI.DataAccess.Quests
{
    public static class DailyCaloriesLimitQuest
    {
        private const string CALORIES_LIMIT_KEY = "CaloriesLimit";

        public static Quest Initialize(Quest quest, User user, QuestTypeAsEmum questTypeAsEmum, AddQuestRequest addQuestRequest)
        {
            if (addQuestRequest.Data.TryGetValue(CALORIES_LIMIT_KEY, out string caloriesLimitValue))
            {
                if (int.TryParse(caloriesLimitValue, out int caloriesLimit))
                {
                    quest.ProgressValue = 0;
                    quest.ProgressCount = caloriesLimit;
                }
            }
            return quest;
        }
    }
}
