using System;
using System.Collections.Generic;
using LevelUpAPI.Helpers;

namespace LevelUpAPI.Dbo
{
    public class QuestType : IObjectWithId
    {
        public enum QuestTypeAsEmum
        {
            Undefined,
            CaloriesGoal,
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
