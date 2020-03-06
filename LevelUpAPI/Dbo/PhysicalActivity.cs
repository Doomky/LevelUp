using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class PhysicalActivity : IObjectWithId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal KcalPerHour { get; set; }
    }
}
