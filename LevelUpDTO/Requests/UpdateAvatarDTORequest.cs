using System;

namespace LevelUpDTO
{
    public class UpdateAvatarDTORequest : DTORequest
    {
        public int NewSize { get; set; }

        public UpdateAvatarDTORequest() : base(Method.POST)
        {
        }
    }
}
