using System;
using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetFoodEntriesDTOResponse : DTOResponse
    {
        public class FoodEntryDTOResponse
        {
            public DateTime Datetime { get; set; }
            public int Servings { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public double? EnergyServing { get; set; }
            public double? SodiumServing { get; set; }
            public double? SaltServing { get; set; }
            public double? FatServing { get; set; }
            public double? SaturatedFatServing { get; set; }
            public double? ProteinsServing { get; set; }
            public double? SugarsServing { get; set; }
            public string ImgUrl { get; set; }

            public FoodEntryDTOResponse(DateTime datetime, int servings, string code, string name, double? energyServing, double? sodiumServing, double? saltServing, double? fatServing, double? saturatedFatServing, double? proteinsServing, double? sugarsServing, string imgUrl)
            {
                Datetime = datetime;
                Servings = servings;
                Code = code;
                Name = name;
                EnergyServing = energyServing;
                SodiumServing = sodiumServing;
                SaltServing = saltServing;
                FatServing = fatServing;
                SaturatedFatServing = saturatedFatServing;
                ProteinsServing = proteinsServing;
                SugarsServing = sugarsServing;
                ImgUrl = imgUrl;
            }
        }

        List<FoodEntryDTOResponse> FoodEntries { get; set; }
    }
}
