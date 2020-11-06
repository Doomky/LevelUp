using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO.Requests
{
    public class GetQuestionDTORequest: DTORequest
    {
        public GetQuestionDTORequest() : base(Method.GET)
        {
        }
    }

}
