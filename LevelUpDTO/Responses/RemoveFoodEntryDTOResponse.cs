using System;

namespace LevelUpDTO
{
    public class RemoveFoodEntryDTOResponse : DTOResponse
    {
        public int FoodEntryId { get; set; }

        public RemoveFoodEntryDTOResponse(int foodEntryId)
        {
            FoodEntryId = foodEntryId;
        }
    }
}
