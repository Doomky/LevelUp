using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;

namespace LevelUpAPI.Dto
{
    public class ClaimQuestDTOResponse
    {
        public string State { get; set; }
        public string XpGain { get; set; }
        public string Message { get; set; }
        public ClaimQuestDTOResponse(QuestState state, string xpGain, string message)
        {
            State = state.ToString();
            XpGain = xpGain;
            Message = message;
        }
    }
}
