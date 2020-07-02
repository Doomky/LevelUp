using System;

namespace LevelUpDTO
{
    public class SignUpDTORequest : DTORequest
    {
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool? Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }

        public SignUpDTORequest() : base(Method.POST)
        {

        }
    }
}
