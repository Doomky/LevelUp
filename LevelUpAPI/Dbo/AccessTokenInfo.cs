using System;

namespace LevelUpAPI.Dbo
{
    public class AccessTokenInfo
    {
        public AccessTokenInfo(User user)
        {
            AccessToken = user.GoogleAccessToken;
            AccessExpiration = user.GoogleAccessExpiration;
        }

        public string AccessToken { get; set; }
        public DateTime? AccessExpiration { get; set; }
    }
}
