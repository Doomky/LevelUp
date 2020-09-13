using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class GetCurrentSkinDTORequest : DTORequest
    {
        public GetCurrentSkinDTORequest() : base(Method.GET)
        {
        }
    }
}
