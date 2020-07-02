using System;

namespace LevelUpDTO
{
    public class ClaimQuestsDTORequest : DTORequest
    {
        public int questId { get; set; }
        public ClaimQuestsDTORequest() : base(Method.POST)
        {
        }
    }
}
