using System;

namespace LevelUpDTO
{
    public class UnlinkGoogleAccountDTOResponse : DTOResponse
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string GoogleAccessToken { get; set; }
        public string GoogleRefreshToken { get; set; }
        public DateTime? GoogleAccessExpiration { get; set; }

        public UnlinkGoogleAccountDTOResponse(
            string login,
            string email,
            string googleAccessToken,
            string googleRefreshToken,
            DateTime? googleAccessExpiration)
        {
            Login = login;
            Email = email;
            GoogleAccessToken = googleAccessToken;
            GoogleRefreshToken = googleRefreshToken;
            GoogleAccessExpiration = googleAccessExpiration;
        }
    }
}
