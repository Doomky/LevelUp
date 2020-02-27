using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class SleepEntries
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal DurationMinutes { get; set; }
        public DateTime Date { get; set; }

        public virtual Users User { get; set; }
    }
}
