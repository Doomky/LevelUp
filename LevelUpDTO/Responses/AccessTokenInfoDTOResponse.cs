using System;

namespace LevelUpDTO
{
    public class AccessTokenInfoDTOResponse : DTOResponse
    {
        public DateTime? AccessExpiration { get; set; }
        public string AccessToken { get; set; }

        public AccessTokenInfoDTOResponse(DateTime? accessExpiration, string accessToken)
        {
            AccessExpiration = accessExpiration;
            AccessToken = accessToken;
        }
    }
}
