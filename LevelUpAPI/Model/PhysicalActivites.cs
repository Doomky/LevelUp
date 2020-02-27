using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class PhysicalActivites
    {
        public PhysicalActivites()
        {
            PhysicalActivitesEntries = new HashSet<PhysicalActivitesEntries>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal KcalPerHour { get; set; }

        public virtual ICollection<PhysicalActivitesEntries> PhysicalActivitesEntries { get; set; }
    }
}
