using LevelUpAPI.Dbo;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.Dbo.QuestType;

namespace LevelUpAPI.DataAccess.Quests
{
    public static class WeeklyPhysicalActivity
    {
        private const string PHYSICAL_ACTIVITIES_GOAL_KEY = "PhysicalActivitiesGoal";
        public static Quest Initialize(Quest quest, User user, QuestTypeAsEmum questTypeAsEmum, AddQuestDTORequest addQuestRequest)
        {
            if (addQuestRequest.Data.TryGetValue(PHYSICAL_ACTIVITIES_GOAL_KEY, out string physicalActivitiesGoalValue))
            {
                if (int.TryParse(physicalActivitiesGoalValue, out int physicalActivitiesGoal))
                {
                    quest.ProgressValue = 0;
                    quest.ProgressCount = physicalActivitiesGoal;
                    quest.ExpirationDate = DateTime.Now.AddDays(7);
                }
            }
            return quest;
        }
    }
}
