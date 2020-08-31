using System;

namespace LevelUpDTO
{
    public class AddPADTOResponse : DTOResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CalPerKgPerHour { get; set; }

        public AddPADTOResponse()
        {

        }

        public AddPADTOResponse(int id, string name, decimal calPerKgPerHour)
        {
            Id = id;
            Name = name;
            CalPerKgPerHour = calPerKgPerHour;
        }
    }
}
