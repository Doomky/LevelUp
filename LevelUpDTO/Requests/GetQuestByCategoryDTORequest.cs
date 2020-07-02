using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class GetQuestByCategoryDTORequest : DTORequest
    {
        public string Category { get; set; }

        public GetQuestByCategoryDTORequest() : base(Method.GET)
        {
        }
    }
}
