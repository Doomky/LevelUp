using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class GetAllSkinsDTORequest : DTORequest
    {
        public GetAllSkinsDTORequest() : base(Method.GET)
        {
        }
    }
}
