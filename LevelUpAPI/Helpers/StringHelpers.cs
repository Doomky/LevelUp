using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestState = LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler.QuestState;

namespace LevelUpAPI.Helpers
{
    public static class StringHelpers
    {
        public static Dbo.QuestType.QuestTypeAsEmum AsQuestTypeEnum(this string type)
        {
            switch (type)
            {
                case "DailySleepGoal":
                case "dailysleepgoal":
                    return Dbo.QuestType.QuestTypeAsEmum.DailySleepGoal;
                case "CaloriesGoal":
                case "caloriesgoal":
                    return Dbo.QuestType.QuestTypeAsEmum.CaloriesGoal;
                case "DailyCaloriesLimit":
                case "dailycalorieslimit":
                    return Dbo.QuestType.QuestTypeAsEmum.DailyCaloriesLimit;
                case "DailyPhysicalActivity":
                case "dailyphysicalactivity":
                    return Dbo.QuestType.QuestTypeAsEmum.DailyPhysicalActivity;
                case "WeeklyPhysicalActivity":
                case "weeklyphysicalactivity":
                    return Dbo.QuestType.QuestTypeAsEmum.WeeklyPhysicalActivity;
                default:
                    return Dbo.QuestType.QuestTypeAsEmum.Undefined;
            }
        }

        public static QuestState? AsQuestStateEnum(this string questState)
        {
            switch (questState)
            {
                case "claimed":
                case "Claimed":
                    return QuestState.Claimed;
                case "failed":
                case "Failed":
                    return QuestState.Failed;
                case "finished":
                case "Finished":
                    return QuestState.Finished;
                case "InProgress":
                case "inprogress":
                    return QuestState.InProgress;
                default:
                    return null;
            }
        }

        public static Dbo.Category.CategoryAsEnum AsCategoryEnum(this string type)
        {
            switch (type)
            {
                case "physicalactivities":
                case "PhysicalActivities":
                    return Dbo.Category.CategoryAsEnum.PhysicalActivity;
                case "nutrition":
                case "Nutrition":
                    return Dbo.Category.CategoryAsEnum.Nutrition;
                case "sleep":
                case "Sleep":
                    return Dbo.Category.CategoryAsEnum.Sleep;
                default:
                    return Dbo.Category.CategoryAsEnum.Undefined;
            }
        }
    }
}
