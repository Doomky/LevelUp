using System;
using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetQuestCategoriesDTOResponse : DTOResponse
    {
        public class CategoryDTOResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public CategoryDTOResponse(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public List<CategoryDTOResponse> Categories { get; set; }

        public GetQuestCategoriesDTOResponse(List<CategoryDTOResponse> categories)
        {
            Categories = categories;
        }
    }
}
