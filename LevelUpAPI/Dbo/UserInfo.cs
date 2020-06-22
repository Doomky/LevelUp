using System;

namespace LevelUpAPI.Dbo
{
    public class UserInfo
    {
        public UserInfo(User user, Avatar avatar)
        {
            Login = user.Login;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Gender = user.Gender == false ? "male" : (user.Gender == true ? "female" : "other");
            WeightKg = user.WeightKg;
            Email = user.Email;
            LastLoginDate = user.LastLoginDate;
            GoogleLinked = (user.GoogleRefreshToken != null);
            Level = avatar.Level;
            Xp = avatar.Xp;
            XpMax = avatar.XpMax;
            Size = avatar.Size;
        }

        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public byte WeightKg { get; set; }
        public string Email { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public bool GoogleLinked { get; set; }

        public int Level { get; set; }

        public int Xp { get; set; }
        public int XpMax { get; set; }
        public int Size { get; set; }
    }
}
