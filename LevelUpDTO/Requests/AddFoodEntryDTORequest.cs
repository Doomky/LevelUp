using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class AddFoodEntryDTORequest : DTORequest
    {
        public int OFFDataId { get; set; }

        public AddFoodEntryDTORequest() : base(Method.POST)
        {

        }
    }
}
