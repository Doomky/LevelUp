using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class GetOFFDataDTORequest : DTORequest
    {
        public string Barcode { get; set; }

        public GetOFFDataDTORequest() : base(Method.GET)
        {

        }
    }
}
