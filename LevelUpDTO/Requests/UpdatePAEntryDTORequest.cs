using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class UpdatePAEntryDTORequest : DTORequest
    {
        public int Id { get; set; }
        public DateTime NewDateTimeStart { get; set; }
        public DateTime NewDateTimeEnd { get; set; }

        public UpdatePAEntryDTORequest() : base(Method.POST)
        {
        }
    }
}
