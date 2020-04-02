using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class OpenFoodFactsCategories
    {
        public OpenFoodFactsCategories()
        {
            OpenFoodFactsDatasCategories = new HashSet<OpenFoodFactsDatasCategories>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OpenFoodFactsDatasCategories> OpenFoodFactsDatasCategories { get; set; }
    }
}
