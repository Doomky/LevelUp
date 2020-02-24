using System;
using System.Collections.Generic;

namespace LevelUpBackend.Model
{
    public partial class Users
    {
        public Users()
        {
            FoodEntries = new HashSet<FoodEntries>();
            PhysicalActivitesEntries = new HashSet<PhysicalActivitesEntries>();
            SleepEntries = new HashSet<SleepEntries>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string LastLoginDate { get; set; }
        public string PasswordHast { get; set; }
        public int AvatarId { get; set; }

        public virtual Avatars Avatar { get; set; }
        public virtual ICollection<FoodEntries> FoodEntries { get; set; }
        public virtual ICollection<PhysicalActivitesEntries> PhysicalActivitesEntries { get; set; }
        public virtual ICollection<SleepEntries> SleepEntries { get; set; }
    }
}
