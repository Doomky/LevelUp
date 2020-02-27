using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class QuestsTypes
    {
        public QuestsTypes()
        {
            Quests = new HashSet<Quests>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Quests> Quests { get; set; }
    }
}
