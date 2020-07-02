using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class GetOFFDataFromCategoryDTORequest : DTORequest
    {
        public string Category { get; set; }

        public GetOFFDataFromCategoryDTORequest() : base(Method.GET)
        {

        }
    }
}
