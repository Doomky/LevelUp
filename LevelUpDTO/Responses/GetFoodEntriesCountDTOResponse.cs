using System;
using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetFoodEntriesCountDTOResponse : DTOResponse
    {
        public class NbFoodEntryByLoginDTOResponse
        {
            public string Login { get; set; }
            public string Name { get; set; }
            public int? Total { get; set; }

            public NbFoodEntryByLoginDTOResponse()
            {

            }

            public NbFoodEntryByLoginDTOResponse(string login, string name, int? total)
            {
                Login = login;
                Name = name;
                Total = total;
            }
        }

        public List<NbFoodEntryByLoginDTOResponse> FoodEntries { get; set; }

        public GetFoodEntriesCountDTOResponse()
        {

        }

        public GetFoodEntriesCountDTOResponse(List<NbFoodEntryByLoginDTOResponse> foodEntries)
        {
            FoodEntries = foodEntries;
        }
    }
}
