using System;
using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetPADTOResponse : DTOResponse
    {
        public class PhysicalActivityDTOResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal CalPerKgPerHour { get; set; }

            public PhysicalActivityDTOResponse(int id, string name, decimal calPerKgPerHour)
            {
                Id = id;
                Name = name;
                CalPerKgPerHour = calPerKgPerHour;
            }
        }

        public List<PhysicalActivityDTOResponse> dtoResponse { get; set; }

        public GetPADTOResponse(List<PhysicalActivityDTOResponse> dtoResponse)
        {
            this.dtoResponse = dtoResponse;
        }
    }
}
