using LevelUpAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess
{
    public static class Category
    {
        public static Dbo.Category.CategoryAsEnum AsEnum(Dbo.Category category)
        {
            return category.Name.AsCategoryEnum();
        }
    }
}
