using System;

namespace LevelUpDTO
{
    public class UpdateAvatarDTOResponse : DTOResponse
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
        public int XpMax { get; set; }
        public int Size { get; set; }

        public UpdateAvatarDTOResponse(
            int id,
            int level,
            int xp,
            int xpMax,
            int size)
        {
            Id = id;
            Level = level;
            Xp = xp;
            XpMax = xpMax;
            Size = size;
        }
    }
}
