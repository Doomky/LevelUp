using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class Categories
    {
        public Categories()
        {
            Advices = new HashSet<Advices>();
            Quests = new HashSet<Quests>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Advices> Advices { get; set; }
        public virtual ICollection<Quests> Quests { get; set; }
    }
}
