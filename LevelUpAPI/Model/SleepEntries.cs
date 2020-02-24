using System;
using System.Collections.Generic;

namespace LevelUpBackend.Model
{
    public partial class SleepEntries
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal DurationMinutes { get; set; }
        public byte[] Date { get; set; }

        public virtual Users User { get; set; }
    }
}
