using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class AddCustomFoodEntryDTORequest : DTORequest
    {
        public AddCustomFoodEntryDTORequest() : base(Method.POST)
        {
        }

        public string Name { get; set; }
        public double? Energy100g { get; set; }
        public double? Sodium100g { get; set; }
        public double? Salt100g { get; set; }
        public double? Fat100g { get; set; }
        public double? SaturatedFat100g { get; set; }
        public double? Proteins100g { get; set; }
        public double? Sugars100g { get; set; }
        public double? EnergyServing { get; set; }
        public double? SodiumServing { get; set; }
        public double? SaltServing { get; set; }
        public double? FatServing { get; set; }
        public double? SaturatedFatServing { get; set; }
        public double? ProteinsServing { get; set; }
        public double? SugarsServing { get; set; }
    }
}
