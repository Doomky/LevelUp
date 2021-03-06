﻿using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class Users
    {
        public Users()
        {
            FoodEntries = new HashSet<FoodEntries>();
            PasswordRecoveryDatas = new HashSet<PasswordRecoveryDatas>();
            PhysicalActivitiesEntries = new HashSet<PhysicalActivitiesEntries>();
            Quests = new HashSet<Quests>();
            SleepEntries = new HashSet<SleepEntries>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool? Gender { get; set; }
        public byte WeightKg { get; set; }
        public string Email { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string PasswordHash { get; set; }
        public int AvatarId { get; set; }
        public string GoogleAccessToken { get; set; }
        public string GoogleRefreshToken { get; set; }
        public DateTime? GoogleAccessExpiration { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Avatars Avatar { get; set; }
        public virtual ICollection<FoodEntries> FoodEntries { get; set; }
        public virtual ICollection<PasswordRecoveryDatas> PasswordRecoveryDatas { get; set; }
        public virtual ICollection<PhysicalActivitiesEntries> PhysicalActivitiesEntries { get; set; }
        public virtual ICollection<Quests> Quests { get; set; }
        public virtual ICollection<SleepEntries> SleepEntries { get; set; }
    }
}
