using LevelUpAPI.DataAccess.QuestHandlers.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.QuestHandlers
{
    public class CaloriesGoalQuestHandler : QuestHandler
    {
        public const string CALORIES_KEY = "Calories";


        public override void Update(UpdateQuestRequest updateQuestRequest)
        {
            if (updateQuestRequest.Datas != null)
            {
                if (updateQuestRequest.Datas.TryGetValue(CALORIES_KEY, out string caloriesAsStr))
                {
                    if (int.TryParse(caloriesAsStr, out int calories))
                    {
                        Quest.ProgressValue += calories;
                    }
                }
            }
        }
    }
}
