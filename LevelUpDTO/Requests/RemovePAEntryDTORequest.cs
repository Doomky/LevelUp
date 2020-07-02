using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class RemovePAEntryDTORequest : DTORequest
    {
        public int Id { get; set; }
        public RemovePAEntryDTORequest() : base(Method.POST)
        {
        }
    }
}
