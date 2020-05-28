using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class PhysicalActivitiesEntries
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PhysicalActivitiesId { get; set; }
        public DateTime DatetimeStart { get; set; }
        public DateTime DatetimeEnd { get; set; }

        public virtual PhysicalActivities PhysicalActivities { get; set; }
        public virtual Users User { get; set; }
    }
}
