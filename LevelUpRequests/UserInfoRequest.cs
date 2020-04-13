using System;

namespace LevelUpRequests
{
    public class UserInfoRequest : Request
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int AvatarId { get; set; }
        public string GoogleId { get; set; }

        public UserInfoRequest() : base(Method.GET)
        {
        }
    }
}
