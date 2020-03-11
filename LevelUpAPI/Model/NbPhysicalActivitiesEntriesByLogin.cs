using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class NbPhysicalActivitiesEntriesByLogin
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public int? Total { get; set; }
    }
}
