using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class FoodEntries
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OpenFoodFactsDataId { get; set; }
        public DateTime Date { get; set; }

        public virtual OpenFoodFactsDatas OpenFoodFactsData { get; set; }
        public virtual Users User { get; set; }
    }
}
