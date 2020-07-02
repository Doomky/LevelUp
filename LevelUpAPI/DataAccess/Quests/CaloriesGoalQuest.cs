using LevelUpAPI.Dbo;
using LevelUpDTO;
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

        public static Quest Initialize(Quest quest, User user, QuestTypeAsEmum questTypeAsEmum, AddQuestDTORequest addQuestRequest)
        {
            if (addQuestRequest.Data.TryGetValue(CALORIES_GOAL_KEY, out string caloriesGoalValue))
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
