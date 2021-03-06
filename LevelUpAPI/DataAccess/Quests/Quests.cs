﻿using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.Dbo.Category;
using static LevelUpAPI.Dbo.QuestType;

namespace LevelUpAPI.DataAccess.Quests
{
    public class Quests
    {
        public static async Task<Quest> Create(
            AddQuestDTORequest addQuestRequest,
            User user,
            IQuestTypeRepository questTypeRepository, 
            ICategoryRepository categoryRepository)
        {
            QuestTypeAsEmum questTypeAsEnum = await questTypeRepository.GetAsEmum(addQuestRequest.TypeId);
            if (questTypeAsEnum == QuestTypeAsEmum.Undefined)
                return null;

            CategoryAsEnum categoryAsEnum = await categoryRepository.GetAsEnum(addQuestRequest.CategoryId);
            if (categoryAsEnum == CategoryAsEnum.Undefined)
                return null;

            Quest quest = new Quest()
            {
                TypeId = addQuestRequest.TypeId,
                CategoryId = addQuestRequest.CategoryId,
                UserId = user.Id,
                XpValue = 10,
                CreationDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(1)
            };

            return Initialize(quest, user, questTypeAsEnum, addQuestRequest);
        }

        private static Quest Initialize(Quest quest, User user, QuestTypeAsEmum questTypeAsEmum, AddQuestDTORequest addQuestRequest)
        {
            switch (questTypeAsEmum)
            {
                case QuestTypeAsEmum.DailySleepGoal:
                    return DailySleepQuest.Initialize(quest, user, questTypeAsEmum, addQuestRequest);
                case QuestTypeAsEmum.CaloriesGoal:
                    return CaloriesGoalQuest.Initialize(quest, user, questTypeAsEmum, addQuestRequest);
                case QuestTypeAsEmum.DailyCaloriesLimit:
                    return DailyCaloriesLimitQuest.Initialize(quest, user, questTypeAsEmum, addQuestRequest);
                case QuestTypeAsEmum.WeeklyPhysicalActivity:
                    return WeeklyPhysicalActivity.Initialize(quest, user, questTypeAsEmum, addQuestRequest);
                case QuestTypeAsEmum.DailyPhysicalActivity:
                    return DailyPhysicalActivityQuest.Initialize(quest, user, questTypeAsEmum, addQuestRequest);
                case QuestTypeAsEmum.Undefined:
                default:
                    return null;
            }
        }
    }
}
