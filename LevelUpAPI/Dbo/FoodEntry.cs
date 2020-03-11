using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class FoodEntry : IObjectWithId
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OpenFoodFactsDataId { get; set; }
        public DateTime Datetime { get; set; }
    }
}
