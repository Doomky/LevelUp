using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class GetFoodEntriesDTORequest : DTORequest
    {
        public GetFoodEntriesDTORequest() : base(Method.GET)
        {
        }
    }
}
