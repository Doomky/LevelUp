using System;
using System.Collections.Generic;

namespace LevelUpDTO
{
    public class UpdateQuestDTOResponse : DTOResponse
    {
        public class Quest
        {
            public int Id { get; set; }
            public int CategoryId { get; set; }
            public int TypeId { get; set; }
            public int ProgressValue { get; set; }
            public int ProgressCount { get; set; }
            public int UserId { get; set; }
            public int? XpValue { get; set; }
            public DateTime CreationDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool IsClaimed { get; set; }
        }

        public IEnumerable<Quest> Quests { get; set; }

        public UpdateQuestDTOResponse(IEnumerable<Quest> quests)
        {
            Quests = quests;
        }
    }
}
