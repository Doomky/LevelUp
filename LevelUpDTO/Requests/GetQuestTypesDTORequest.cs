using System;

namespace LevelUpDTO
{
    public class GetQuestTypesDTORequest : DTORequest
    {
        public string Category;
        public GetQuestTypesDTORequest() : base(Method.GET)
        {
        }
    }
}
