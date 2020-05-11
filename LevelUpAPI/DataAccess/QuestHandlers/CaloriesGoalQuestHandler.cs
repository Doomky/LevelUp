﻿using LevelUpAPI.DataAccess.QuestHandlers.Interfaces;
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

        public override QuestState GetState()
        {
            if (Quest.ProgressValue <= Quest.ProgressCount)
                return Quest.ExpirationDate <= DateTime.Now ? QuestState.Finished : QuestState.InProgress;
            else
                return QuestState.Failed;
        }

        public override QuestState Update(UpdateQuestRequest updateQuestRequest)
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
            return GetState();
        }
    }
}
