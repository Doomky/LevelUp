using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class User : IObjectWithId
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string PasswordHash { get; set; }
        public int AvatarId { get; set; }
        public string GoogleId { get; set; }
    }
}
