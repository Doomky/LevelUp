using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class SleepEntry : IObjectWithId
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal DurationMinutes { get; set; }
        public DateTime Date { get; set; }
    }
}
