using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class RemoveFoodEntryDTORequest : DTORequest
    {
        public int Id { get; set; }

        public RemoveFoodEntryDTORequest() : base(Method.POST)
        {

        }
    }
}
