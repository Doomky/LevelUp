using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class LinkGoogleAccountDTORequest : DTORequest
    {
        public string GoogleAuthCode { get; set; }
        public LinkGoogleAccountDTORequest() : base(Method.POST)
        {

        }
    }
}
