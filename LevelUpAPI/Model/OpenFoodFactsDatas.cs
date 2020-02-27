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
        public int Code { get; set; }
        public string Name { get; set; }
        public string Protein { get; set; }
        public string Glucide { get; set; }

        public virtual ICollection<FoodEntries> FoodEntries { get; set; }
    }
}
