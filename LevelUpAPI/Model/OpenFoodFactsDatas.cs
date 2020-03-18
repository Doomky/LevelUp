using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class OpenFoodFactsDatas
    {
        public OpenFoodFactsDatas()
        {
            FoodEntries = new HashSet<FoodEntries>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double? Energy100g { get; set; }
        public double? Sodium100g { get; set; }
        public double? Salt100g { get; set; }
        public double? Fat100g { get; set; }
        public double? SaturedFat100g { get; set; }
        public double? Protein100g { get; set; }

        public virtual ICollection<FoodEntries> FoodEntries { get; set; }
    }
}
