using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class QuestType : IObjectWithId
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
