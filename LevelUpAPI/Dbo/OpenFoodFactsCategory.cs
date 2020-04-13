using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Dbo
{
    public class OpenFoodFactsCategory : IObjectWithId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
