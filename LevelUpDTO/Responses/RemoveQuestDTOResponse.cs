using System;

namespace LevelUpDTO
{
    public class RemoveQuestDTOResponse : DTOResponse
    {
        public int QuestId { get; set; }

        public RemoveQuestDTOResponse(int questId)
        {
            QuestId = questId;
        }
    }
}
