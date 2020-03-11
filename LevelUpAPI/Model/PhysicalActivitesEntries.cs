using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class PhysicalActivitesEntries
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PhysicalActivitesId { get; set; }
        public DateTime? Datetime { get; set; }

        public virtual PhysicalActivites PhysicalActivites { get; set; }
        public virtual Users User { get; set; }
    }
}
