using System;

namespace LevelUpDTO
{
    public class UpdateAvatarDTOResponse : DTOResponse
    {
        public int Id { get; set; }
        public int Size { get; set; }

        public UpdateAvatarDTOResponse(
            int id,
            int size)
        {
            Id = id;
            Size = size;
        }
    }
}
