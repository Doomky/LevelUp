using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class Skin : IObjectWithId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LevelMin { get; set; }
    }
}
