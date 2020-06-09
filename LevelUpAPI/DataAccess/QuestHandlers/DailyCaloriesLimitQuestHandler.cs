using LevelUpAPI.DataAccess.QuestHandlers.Interfaces;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;

namespace LevelUpAPI.DataAccess.QuestHandlers
{
    public class DailyCaloriesLimitQuestHandler : QuestHandler
    {
        public const string CALORIES_KEY = "Calories";

        public override QuestState GetState()
        {
            if (Quest.ProgressValue > Quest.ProgressCount)
                return QuestState.Failed;
            else
                return Quest.ExpirationDate > DateTime.Now ? QuestState.InProgress : QuestState.Finished;
        }

        private void UpdateCalories(string caloriesAsStr)
        {
            if (int.TryParse(caloriesAsStr, out int calories))
            {
                Quest.ProgressValue += calories;
            }
        }

        public override QuestState Update(UpdateQuestRequest updateQuestRequest)
        {
            if (updateQuestRequest.Data != null)
            {
                if (updateQuestRequest.Data.TryGetValue(CALORIES_KEY, out string caloriesAsStr))
                {
                    UpdateCalories(caloriesAsStr);
                }
            }
            return GetState();
        }

        public override QuestState Update(string key, string value)
        {
            if (key.Equals(CALORIES_KEY))
            {
                UpdateCalories(value);
            }
            return GetState();
        }
    }
}
