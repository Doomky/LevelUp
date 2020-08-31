using System;

namespace LevelUpDTO
{
    public class UpdateFoodEntryDTOResponse : DTOResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OpenFoodFactsDataId { get; set; }
        public DateTime Datetime { get; set; }
        public int Servings { get; set; }

        public UpdateFoodEntryDTOResponse()
        {

        }

        public UpdateFoodEntryDTOResponse(
            int id,
            int userId,
            int openFoodFactsDataId,
            DateTime datetime,
            int servings)
        {
            Id = id;
            UserId = userId;
            OpenFoodFactsDataId = openFoodFactsDataId;
            Datetime = datetime;
            Servings = servings;
        }
    }
}
