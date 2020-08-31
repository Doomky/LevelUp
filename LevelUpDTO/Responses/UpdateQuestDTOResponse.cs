using System.Collections.Generic;

namespace LevelUpDTO
{
    public class UpdateQuestDTOResponse : DTOResponse
    {
        public List<QuestDTOResponse> Quests { get; set; }

        public UpdateQuestDTOResponse()
        {

        }

        public UpdateQuestDTOResponse(List<QuestDTOResponse> quests)
        {
            Quests = quests;
        }
    }
}
