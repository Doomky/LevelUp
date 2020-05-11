using LevelUpAPI.DataAccess.QuestHandlers.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
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


        public override UpdateResult Update(UpdateQuestRequest updateQuestRequest)
        {
            if (updateQuestRequest.Data != null)
            {
                if (updateQuestRequest.Data.TryGetValue(CALORIES_KEY, out string caloriesAsStr))
                {
                    if (int.TryParse(caloriesAsStr, out int calories))
                    {
                        Quest.ProgressValue += calories;
                    }
                }
            }
            if (Quest.ProgressValue <= Quest.ProgressCount)
                return UpdateResult.InProgress;
            else
                return UpdateResult.Failed;
        }
    }
}
