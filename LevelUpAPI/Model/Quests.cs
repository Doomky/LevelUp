using System;
using System.Collections.Generic;

namespace LevelUpBackend.Model
{
    public partial class Quests
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public int ProgressValue { get; set; }
        public int ProgressCount { get; set; }

        public virtual Categories Category { get; set; }
        public virtual QuestsTypes Type { get; set; }
    }
}
