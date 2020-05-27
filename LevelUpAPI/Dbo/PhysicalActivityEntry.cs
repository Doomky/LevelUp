using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class PhysicalActivityEntry : IObjectWithId
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PhysicalActivitesId { get; set; }
        public DateTime DatetimeStart { get; set; }
        public DateTime DatetimeEnd { get; set; }
    }
}
