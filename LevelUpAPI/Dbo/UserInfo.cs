using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Dbo
{
    public class UserInfo
    {
        public UserInfo(Dbo.User user)
        {
            Login = user.Login;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            LastLoginDate = user.LastLoginDate;
            GoogleLinked = (user.GoogleRefreshToken != null);
        }

        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public bool GoogleLinked { get; set; }
    }
}
