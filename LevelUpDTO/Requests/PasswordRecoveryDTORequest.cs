using System;

namespace LevelUpDTO
{
    public class PasswordRecoveryDTORequest : DTORequest
    {
        public string Hash { get; set; }
        public string PasswordHash { get; set; }

        public PasswordRecoveryDTORequest() : base(Method.POST)
        {
        }
    }
}
