using LevelUpAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess
{
    public static class QuestType
    {
        public static Dbo.QuestType.QuestTypeAsEmum AsEnum(Dbo.QuestType questType)
        {
            return questType.Name.AsQuestTypeEnum();
        }
    }
}
