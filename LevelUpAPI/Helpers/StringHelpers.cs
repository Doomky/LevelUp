using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Helpers
{
    public static class StringHelpers
    {
        public static Dbo.QuestType.QuestTypeAsEmum AsQuestTypeEnum(this string type)
        {
            switch (type)
            {
                case "CaloriesGoal":
                    return Dbo.QuestType.QuestTypeAsEmum.CaloriesGoal;
                case "DailyCaloriesLimit":
                    return Dbo.QuestType.QuestTypeAsEmum.DailyCaloriesLimit;
                case "DailyPhysicalActivity":
                    return Dbo.QuestType.QuestTypeAsEmum.DailyPhysicalActivity;
                case "WeeklyPhysicalActivity":
                    return Dbo.QuestType.QuestTypeAsEmum.WeeklyPhysicalActivity;
                default:
                    return Dbo.QuestType.QuestTypeAsEmum.Undefined;
            }
        }

        public static Dbo.Category.CategoryAsEnum AsCategoryEnum(this string type)
        {
            switch (type)
            {
                case "PhysicalActivities":
                    return Dbo.Category.CategoryAsEnum.PhysicalActivity;
                case "Nutrition":
                    return Dbo.Category.CategoryAsEnum.Nutrition;
                default:
                    return Dbo.Category.CategoryAsEnum.Undefined;
            }
        }
    }
}
