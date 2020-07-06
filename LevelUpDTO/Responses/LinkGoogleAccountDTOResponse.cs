using System;

namespace LevelUpDTO
{
    public class LinkGoogleAccountDTOResponse : DTOResponse
    {
        public string AccessToken { get; set; }
        public DateTime? AccessExpiration { get; set; }

        public LinkGoogleAccountDTOResponse(string accessToken, DateTime? accessExpiration)
        {
            AccessToken = accessToken;
            AccessExpiration = accessExpiration;
        }
    }
}
