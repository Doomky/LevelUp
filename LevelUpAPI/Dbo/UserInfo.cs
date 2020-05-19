using System;

namespace LevelUpAPI.Dbo
{
    public class UserInfo
    {
        public UserInfo(User user)
        {
            Login = user.Login;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            LastLoginDate = user.LastLoginDate;
        }

        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
