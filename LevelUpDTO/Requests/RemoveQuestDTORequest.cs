using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class RemoveQuestDTORequest : DTORequest
    {
        public int QuestId { get; set; }

        public RemoveQuestDTORequest() : base(Method.POST)
        {
        }
    }
}
