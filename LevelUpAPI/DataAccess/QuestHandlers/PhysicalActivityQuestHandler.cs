using LevelUpAPI.DataAccess.QuestHandlers.Interfaces;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;

namespace LevelUpAPI.DataAccess.QuestHandlers
{
    public class PhysicalActivityQuestHandler : QuestHandler
    {
        public const string PHYSICAL_ACTIVTY_KEY = "PhysicalActivity";

        public override IQuestHandler.QuestState GetState()
        {
            if (Quest.ExpirationDate > DateTime.Now)
                return Quest.ProgressValue < Quest.ProgressCount ? QuestState.Finished : QuestState.InProgress;
            else
                return QuestState.Failed;
        }

        private void UpdatePhyiscalActivity(string physicalActivityCountAsStr)
        {
            if (int.TryParse(physicalActivityCountAsStr, out int physicalActivityCount))
            {
                Quest.ProgressValue += physicalActivityCount;
            }
        }

        public override IQuestHandler.QuestState Update(UpdateQuestRequest updateQuestRequest)
        {
            if (updateQuestRequest.Data != null)
            {
                if (updateQuestRequest.Data.TryGetValue(PHYSICAL_ACTIVTY_KEY, out string physicalActivityCountAsStr))
                {
                    UpdatePhyiscalActivity(physicalActivityCountAsStr);

                }
            }
            return GetState();
        }

        public override IQuestHandler.QuestState Update(string key, string value)
        {
            if (key.Equals(PHYSICAL_ACTIVTY_KEY))
            {
                UpdatePhyiscalActivity(value);
            }
            return GetState();
        }
    }
}
