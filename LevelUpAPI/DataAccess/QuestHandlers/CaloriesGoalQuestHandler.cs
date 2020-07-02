using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;

namespace LevelUpAPI.DataAccess.QuestHandlers
{
    public class CaloriesGoalQuestHandler : QuestHandler
    {
        public const string CALORIES_KEY = "Calories";

        public override QuestState GetState()
        {
            if (Quest.IsClaimed)
                return QuestState.Claimed;
            else if (Quest.ExpirationDate > DateTime.Now)
                return Quest.ProgressValue >= Quest.ProgressCount ? QuestState.Finished : QuestState.InProgress;
            else
                return QuestState.Failed;
        }

        private void UpdateCalories(string caloriesAsStr)
        {
            if (int.TryParse(caloriesAsStr, out int calories))
            {
                Quest.ProgressValue += calories;
            }
        }

        public override QuestState Update(UpdateQuestDTORequest updateQuestRequest)
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
