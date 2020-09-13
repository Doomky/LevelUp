using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class GetAvailableSkinsDTORequest : DTORequest
    {
        public GetAvailableSkinsDTORequest() : base(Method.GET)
        {
        }
    }
}
