﻿using LevelUpAPI.DataAccess.QuestHandlers.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;

namespace LevelUpAPI.DataAccess.QuestHandlers
{
    public abstract class QuestHandler : IQuestHandler
    {
        public Quest Quest { get; set; }
        public abstract QuestState Update(UpdateQuestDTORequest updateQuestRequest);

        public abstract QuestState Update(string key, string value);

        public abstract QuestState GetState();
    }
}
