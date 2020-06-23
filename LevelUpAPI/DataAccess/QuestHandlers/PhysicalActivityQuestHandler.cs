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

        public override QuestState GetState()
        {
            if (Quest.IsClaimed)
                return QuestState.Claimed;
            else if (Quest.ProgressValue >= Quest.ProgressCount)
                return QuestState.Finished ;
            else
                return Quest.ExpirationDate > DateTime.Now ? QuestState.InProgress : QuestState.Failed;
        }

        private void UpdatePhyiscalActivity(string physicalActivityCountAsStr)
        {
            if (int.TryParse(physicalActivityCountAsStr, out int physicalActivityCount))
            {
                Quest.ProgressValue += physicalActivityCount;
            }
        }

        public override QuestState Update(UpdateQuestRequest updateQuestRequest)
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

        public override QuestState Update(string key, string value)
        {
            if (key.Equals(PHYSICAL_ACTIVTY_KEY))
            {
                UpdatePhyiscalActivity(value);
            }
            return GetState();
        }
    }
}
