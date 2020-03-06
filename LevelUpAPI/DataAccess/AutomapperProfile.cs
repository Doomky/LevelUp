using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess
{
    public class AutomapperProfile : Profile
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                    ConfWithProfile();
                return _mapper;
            }
        }

        private static void ConfWithProfile()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutomapperProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public AutomapperProfile()
        {
            AddTwoWayMapping<Dbo.Advice, Model.Advices>();
            AddTwoWayMapping<Dbo.Avatar, Model.Avatars>();
            AddTwoWayMapping<Dbo.Category, Model.Categories>();
            AddTwoWayMapping<Dbo.FoodEntry, Model.FoodEntries>();
            AddTwoWayMapping<Dbo.OpenFoodFactsData, Model.OpenFoodFactsDatas>();
            AddTwoWayMapping<Dbo.PhysicalActivity, Model.PhysicalActivites>();
            AddTwoWayMapping<Dbo.PhysicalActivityEntry, Model.PhysicalActivitesEntries>();
            AddTwoWayMapping<Dbo.Quest, Model.Quests>();
            AddTwoWayMapping<Dbo.QuestType, Model.QuestsTypes>();
            AddTwoWayMapping<Dbo.SleepEntry, Model.SleepEntries>();
            AddTwoWayMapping<Dbo.User, Model.Users>();
        }

        public void AddTwoWayMapping<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
