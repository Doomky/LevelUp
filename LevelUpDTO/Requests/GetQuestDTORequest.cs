using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class GetQuestDTORequest : DTORequest
    {
        public string QuestState { get; set; }
        public GetQuestDTORequest() : base(Method.GET)
        {
        }
    }
}
