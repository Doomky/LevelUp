﻿using LevelUpAPI.Dbo;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.QuestHandlers.Interfaces
{
    public interface IQuestHandler
    {
        public enum QuestState
        {
            InProgress,
            Failed,
            Finished
        }

        public Quest Quest { get; set; }
        public QuestState Update(UpdateQuestRequest updateQuestRequest);

        public QuestState GetState();
    }
}