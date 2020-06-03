using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class PhysicalActivities
    {
        public PhysicalActivities()
        {
            PhysicalActivitiesEntries = new HashSet<PhysicalActivitiesEntries>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CalPerKgPerHour { get; set; }

        public virtual ICollection<PhysicalActivitiesEntries> PhysicalActivitiesEntries { get; set; }
    }
}
