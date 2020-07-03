using System;

namespace LevelUpDTO
{
    public class ClaimQuestsDTOResponse : DTOResponse
    {
        public string State { get; set; }
        public string XpGain { get; set; }
        public string Message { get; set; }
        public ClaimQuestsDTOResponse(string state, string xpGain, string message)
        {
            State = state;
            XpGain = xpGain;
            Message = message;
        }
    }
}
