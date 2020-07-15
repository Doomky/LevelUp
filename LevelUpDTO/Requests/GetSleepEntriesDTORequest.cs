using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO.Requests
{
    public class GetSleepEntriesDTORequest : DTORequest
    {
        public GetSleepEntriesDTORequest() : base(Method.GET)
        {
        }
    }
}
