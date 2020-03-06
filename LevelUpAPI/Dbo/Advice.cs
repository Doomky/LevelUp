using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class Advice : IObjectWithId
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Text { get; set; }
    }
}
