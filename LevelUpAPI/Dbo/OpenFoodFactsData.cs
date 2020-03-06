using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class OpenFoodFactsData : IObjectWithId
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Protein { get; set; }
        public string Glucide { get; set; }
    }
}
