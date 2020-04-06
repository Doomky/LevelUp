using LevelUpAPI.Dbo;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.Dbo.QuestType;

namespace LevelUpAPI.DataAccess.Quests
{
    public static class CaloriesGoalQuest
    {
        private const string CALORIES_GOAL_KEY = "CaloriesGoal";

        public static Dbo.Quest Initialize(Dbo.Quest quest, Dbo.User user, QuestTypeAsEmum questTypeAsEmum, AddQuestRequest addQuestRequest)
        {
            if (addQuestRequest.Datas.TryGetValue(CALORIES_GOAL_KEY, out string caloriesGoalValue))
            {
                if (int.TryParse(caloriesGoalValue, out int caloriesGoal))
                {
                    quest.ProgressValue = 0;
                    quest.ProgressCount = caloriesGoal;
                }
            }
            return quest;
        }
    }
}
