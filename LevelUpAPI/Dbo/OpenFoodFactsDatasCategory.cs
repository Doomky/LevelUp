using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Dbo
{
    public class OpenFoodFactsDatasCategory : IObjectWithId
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int DataId { get; set; }
    }
}
