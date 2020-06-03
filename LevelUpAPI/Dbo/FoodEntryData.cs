using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Dbo
{
    public class FoodEntryData
    {
        public FoodEntryData(FoodEntry entry, OpenFoodFactsData data)
        {
            Datetime = entry.Datetime;
            Servings = entry.Servings;
            Code = data.Code;
            Name = data.Name;
            EnergyServing = data.EnergyServing;
            SodiumServing = data.SodiumServing;
            SaltServing = data.SaltServing;
            FatServing = data.FatServing;
            SaturatedFatServing = data.SaturatedFatServing;
            ProteinsServing = data.ProteinsServing;
            SugarsServing = data.SugarsServing;
            ImgUrl = data.ImgUrl;
        }

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
    }
}
