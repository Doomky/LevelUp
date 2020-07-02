using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class AddQuestDTORequest : DTORequest
    {
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public Dictionary<string, string> Data { get; set; }

        public AddQuestDTORequest() : base(Method.POST)
        {
        }
    }
}
