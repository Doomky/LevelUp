using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
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
        public static async Task<Dbo.Quest> Create(
            AddQuestRequest addQuestRequest,
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
                UserId = user.Id
            };

            return Initialize(quest, user, questTypeAsEnum, addQuestRequest);
        }

        private static Dbo.Quest Initialize(Dbo.Quest quest, User user, QuestTypeAsEmum questTypeAsEmum, AddQuestRequest addQuestRequest)
        {
            switch (questTypeAsEmum)
            {
                case QuestTypeAsEmum.CaloriesGoal:
                    return CaloriesGoalQuest.Initialize(quest, user, questTypeAsEmum, addQuestRequest);
                case QuestTypeAsEmum.Undefined:
                default:
                    return null;
            }
        }
    }
}
