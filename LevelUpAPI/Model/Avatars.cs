using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class Avatars
    {
        public Avatars()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
        public int XpMax { get; set; }
        public int Size { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
