using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            AddTwoWayMapping<Dbo.Advice, Model.Advices>();
            AddTwoWayMapping<Dbo.Avatar, Model.Avatars>();
            AddTwoWayMapping<Dbo.Category, Model.Categories>();
            AddTwoWayMapping<Dbo.FoodEntry, Model.FoodEntries>();
            AddTwoWayMapping<Dbo.OpenFoodFactsData, Model.OpenFoodFactsDatas>();
            AddTwoWayMapping<Dbo.PhysicalActivity, Model.PhysicalActivities>();
            AddTwoWayMapping<Dbo.PhysicalActivityEntry, Model.PhysicalActivitiesEntries>();
            AddTwoWayMapping<Dbo.Quest, Model.Quests>();
            AddTwoWayMapping<Dbo.QuestType, Model.QuestsTypes>();
            AddTwoWayMapping<Dbo.SleepEntry, Model.SleepEntries>();
            AddTwoWayMapping<Dbo.User, Model.Users>();
            AddTwoWayMapping<Dbo.NbFoodEntryByLogin, Model.NbFoodEntriesByLogin>();
            AddTwoWayMapping<Dbo.NbPhysicalActivityEntryByLogin, Model.NbPhysicalActivitiesEntriesByLogin>();
            AddTwoWayMapping<Dbo.PasswordRecoveryData, Model.PasswordRecoveryDatas>();
            AddTwoWayMapping<Dbo.OpenFoodFactsCategory, Model.OpenFoodFactsCategories>();
            AddTwoWayMapping<Dbo.OpenFoodFactsDatasCategory, Model.OpenFoodFactsDatasCategories>();
            AddTwoWayMapping<Dbo.PhysicalActivityEntry, Model.PhysicalActivitiesEntries>();
        }

        public void AddTwoWayMapping<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
