using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class PhysicalActivitiesEntriesByLogin
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public decimal KcalPerHour { get; set; }
        public DateTime DatetimeStart { get; set; }
        public DateTime DatetimeEnd { get; set; }
        public DateTime? Duration { get; set; }
    }
}
