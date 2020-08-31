using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetQuestByCategoryDTOResponse : DTOResponse
    {
        public List<QuestDTOResponse> Quests { get; set; }

        public GetQuestByCategoryDTOResponse()
        {

        }

        public GetQuestByCategoryDTOResponse(List<QuestDTOResponse> quests)
        {
            Quests = quests;
        }
    }
}
