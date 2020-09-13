using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class Skins
    {
        public Skins()
        {
            Avatars = new HashSet<Avatars>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int LevelMin { get; set; }

        public virtual ICollection<Avatars> Avatars { get; set; }
    }
}
