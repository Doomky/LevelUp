using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class UpdateFoodEntryDTORequest : DTORequest
    {
        public int Id { get; set; }
        public int OFFDataId { get; set; }
        public DateTime DateTime { get; set; }

        public UpdateFoodEntryDTORequest() : base(Method.POST)
        {

        }
    }
}
