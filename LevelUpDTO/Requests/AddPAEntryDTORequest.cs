using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class AddPAEntryDTORequest : DTORequest
    {
        public string Name { get; set; }
        public string dateTimeStart { get; set; }
        public string dateTimeEnd { get; set; }

        public AddPAEntryDTORequest() : base(Method.POST)
        {
        }
    }
}
