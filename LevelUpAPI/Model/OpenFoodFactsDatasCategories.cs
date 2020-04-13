using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class OpenFoodFactsDatasCategories
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int DataId { get; set; }

        public virtual OpenFoodFactsCategories Category { get; set; }
        public virtual OpenFoodFactsDatas Data { get; set; }
    }
}
