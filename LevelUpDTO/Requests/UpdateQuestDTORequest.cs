using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class UpdateQuestDTORequest : DTORequest
    {
        public Dictionary<string, string> Data { get; set; }

        public UpdateQuestDTORequest() : base(Method.POST)
        {

        }
    }
}
