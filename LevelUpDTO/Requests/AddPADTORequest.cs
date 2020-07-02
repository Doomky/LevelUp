using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class AddPADTORequest : DTORequest
    {
        public string Name { get; set; }
        public double? CalPerKgPerHour { get; set; }

        public AddPADTORequest() : base(Method.POST)
        {
        }
    }
}
