using System;

namespace LevelUpDTO
{
    public class RemovePAEntryDTOResponse : DTOResponse
    {
        public int PAEntryId { get; set; }

        public RemovePAEntryDTOResponse(int paEntryId)
        {
            PAEntryId = paEntryId;
        }
    }
}
