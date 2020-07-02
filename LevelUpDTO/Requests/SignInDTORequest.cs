using System;

namespace LevelUpDTO
{
    public class SignInDTORequest : DTORequest
    {
        public string Login { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }

        public SignInDTORequest() : base(Method.POST)
        {
        }
    }
}
