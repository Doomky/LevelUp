using System;
using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetQuestByCategoryDTOResponse : DTOResponse
    {
        public class QuestDTOResponse2
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

            public QuestDTOResponse2(int id, int categoryId, int typeId, int progressValue, int progressCount, int userId, int? xpValue, DateTime creationDate, DateTime expirationDate, bool isClaimed)
            {
                Id = id;
                CategoryId = categoryId;
                TypeId = typeId;
                ProgressValue = progressValue;
                ProgressCount = progressCount;
                UserId = userId;
                XpValue = xpValue;
                CreationDate = creationDate;
                ExpirationDate = expirationDate;
                IsClaimed = isClaimed;
            }
        }

        public List<QuestDTOResponse2> Quests { get; set; }

        public GetQuestByCategoryDTOResponse(List<QuestDTOResponse2> quests)
        {
            Quests = quests;
        }
    }
}
