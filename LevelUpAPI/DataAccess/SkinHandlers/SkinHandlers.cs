using LevelUpAPI.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelUpAPI.Helpers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.DataAccess.GoogleFit;
using LevelUpAPI.DataAccess.Quests;
using LevelUpAPI.DataAccess.Repositories;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;

namespace LevelUpAPI.DataAccess.SkinHandlers
{
    public class SkinInformations
    {
        public SkinInformations(string description, bool unlocked)
        {
            Description = description;
            Unlocked = unlocked;
        }

        public string Description { get; set; }

        public bool Unlocked { get; set; }
    }

    public static class SkinHandlers
    {
        public static async Task<SkinInformations> Handle(User user, Skin skin, IAvatarRepository avatarRepository, ICategoryRepository categoryRepository, IQuestTypeRepository questTypeRepository, IQuestRepository questRepository)
        {
            Skin.SkinNameAsEnum skinName =  skin.Name.AsSkinEnum();
            SkinInformations skinInformations = null;
            switch (skinName)
            {
                case Skin.SkinNameAsEnum.man_default:
                case Skin.SkinNameAsEnum.woman_default:
                    skinInformations = new SkinInformations("default skin", true);
                    break;
                case Skin.SkinNameAsEnum.man_pyjama:
                case Skin.SkinNameAsEnum.woman_pyjama:
                    Dbo.Category sleepCategory = await categoryRepository.GetByName(Dbo.Category.CategoryAsEnum.Sleep.ToString());
                    IEnumerable<Quest> quests = (await questRepository.Get(user, sleepCategory.Id, questTypeRepository, null))
                        .Where(quest => {
                            QuestState questState = QuestHandlers.QuestHandlers.Create(quest, user, questTypeRepository).GetState();

                            return questState == QuestState.Claimed || questState == QuestState.Finished;
                        });
                    int numberOfSleepQuestCompleted = quests.Count();
                    int numberOfSleepQuestGoal = 5;
                    skinInformations = new SkinInformations($"do at least {numberOfSleepQuestGoal} sleep quests (current: {numberOfSleepQuestCompleted})", numberOfSleepQuestCompleted >= numberOfSleepQuestGoal);
                    break;
                case Skin.SkinNameAsEnum.man_fancy:
                case Skin.SkinNameAsEnum.woman_fancy:
                    Avatar avatar = await avatarRepository.GetByUser(user);
                    int fancyLevelGoal = 10;
                    skinInformations = new SkinInformations($"reach level {10} (current: {avatar.Level})", avatar.Level >= fancyLevelGoal);
                    break;
                default:
                case Skin.SkinNameAsEnum.unknown:
                    skinInformations = new SkinInformations("???", false);
                    break;
            }
            return skinInformations;
        }
    }
}
