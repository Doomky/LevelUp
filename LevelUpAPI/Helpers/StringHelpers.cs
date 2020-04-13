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
                default:
                    return Dbo.QuestType.QuestTypeAsEmum.Undefined;
            }
        }

        public static Dbo.Category.CategoryAsEnum AsCategoryEnum(this string type)
        {
            switch (type)
            {
                case "Nutrition":
                    return Dbo.Category.CategoryAsEnum.Nutrition;
                default:
                    return Dbo.Category.CategoryAsEnum.Undefined;
            }
        }
    }
}
