using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO.Responses
{
    public class GetAvailableSkinsDTOResponse
    {
        public GetAvailableSkinsDTOResponse(int id, string name, int levelMin, string description, bool unlocked)
        {
            Id = id;
            Name = name;
            LevelMin = levelMin;
            Description = description;
            Unlocked = unlocked;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int LevelMin { get; set; }

        public string Description { get; set; }

        public bool Unlocked { get; set; }
    }
}
