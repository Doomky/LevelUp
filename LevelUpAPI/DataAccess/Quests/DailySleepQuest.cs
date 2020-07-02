﻿using LevelUpAPI.Dbo;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.Dbo.QuestType;

namespace LevelUpAPI.DataAccess.Quests
{
    public static class DailySleepQuest
    {
        public static Quest Initialize(Quest quest, User user, QuestTypeAsEmum questTypeAsEmum, AddQuestDTORequest addQuestRequest)
        {
            quest.ProgressValue = 0;
            quest.ProgressCount = 1;
            return quest;
        }
    }
}
