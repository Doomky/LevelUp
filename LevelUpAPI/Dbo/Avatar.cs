using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class Avatar : IObjectWithId
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
        public int XpMax { get; set; }
        public int Size { get; set; }
        public int SkinId { get; set; }
    }
}
