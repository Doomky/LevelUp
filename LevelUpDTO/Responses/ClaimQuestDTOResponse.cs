using System;

namespace LevelUpDTO
{
    public class ClaimQuestDTOResponse : DTOResponse
    {
        public string State { get; set; }
        public string XpGain { get; set; }
        public string Message { get; set; }
        public ClaimQuestDTOResponse(string state, string xpGain, string message)
        {
            State = state;
            XpGain = xpGain;
            Message = message;
        }
    }
}
