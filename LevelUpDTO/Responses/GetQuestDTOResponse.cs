using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetQuestDTOResponse : DTOResponse
    {
        public List<QuestDTOResponse> QuestDTOResponses { get; set; }

        public GetQuestDTOResponse()
        {

        }

        public GetQuestDTOResponse(List<QuestDTOResponse> questDTOResponses)
        {
            QuestDTOResponses = questDTOResponses;
        }
    }
}
