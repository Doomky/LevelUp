using System;
using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetQuestTypesDTOResponse : DTOResponse
    {
        public class QuestTypesDTOResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public QuestTypesDTOResponse(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        
        public List<QuestTypesDTOResponse> QuestTypes { get; set; }

        public GetQuestTypesDTOResponse(List<QuestTypesDTOResponse> questTypes)
        {
            this.QuestTypes = questTypes;
        }
    }
}
