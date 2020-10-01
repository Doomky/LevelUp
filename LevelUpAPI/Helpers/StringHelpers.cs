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

        public static Dbo.Skin.SkinNameAsEnum AsSkinEnum(this string type)
        {
            switch (type)
            {
                case "man_default":
                case "manDefault":
                case "ManDefault":
                    return Dbo.Skin.SkinNameAsEnum.man_default;
                case "woman_default":
                case "womanDefault":
                case "WomanDefault":
                    return Dbo.Skin.SkinNameAsEnum.woman_default;
                case "man_pyjama":
                case "manPyjama":
                case "ManPyjama":
                    return Dbo.Skin.SkinNameAsEnum.man_pyjama;
                case "woman_pyjama":
                case "womanPyjama":
                case "WomanPyjama":
                    return Dbo.Skin.SkinNameAsEnum.woman_pyjama;
                case "man_fancy":
                case "manFancy":
                case "ManFancy":
                    return Dbo.Skin.SkinNameAsEnum.man_fancy;
                case "woman_fancy":
                case "womanFancy":
                case "WomanFancy":
                    return Dbo.Skin.SkinNameAsEnum.woman_fancy;
                default:
                    return Dbo.Skin.SkinNameAsEnum.unknown;
            }
        }
    }
}
