using System;
using System.Collections.Generic;

namespace LevelUpBackend.Model
{
    public partial class PhysicalActivitesEntries
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PhysicalActivitesId { get; set; }
        public byte[] Date { get; set; }

        public virtual PhysicalActivites PhysicalActivites { get; set; }
        public virtual Users User { get; set; }
    }
}
