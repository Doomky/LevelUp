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
    }
}
