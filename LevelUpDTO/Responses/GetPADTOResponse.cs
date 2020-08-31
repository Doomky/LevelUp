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

            public PhysicalActivityDTOResponse()
            {

            }

            public PhysicalActivityDTOResponse(int id, string name, decimal calPerKgPerHour)
            {
                Id = id;
                Name = name;
                CalPerKgPerHour = calPerKgPerHour;
            }
        }

        public List<PhysicalActivityDTOResponse> PhysicalActivities { get; set; }

        public GetPADTOResponse()
        {

        }

        public GetPADTOResponse(List<PhysicalActivityDTOResponse> physicalActivities)
        {
            PhysicalActivities = physicalActivities;
        }
    }
}
