using System;

namespace LevelUpDTO
{
    public class ChangePasswordDTORequest : DTORequest
    {
        public string PasswordHash { get; set; }
        public string NewPasswordHash { get; set; }
        public ChangePasswordDTORequest() : base(Method.POST)
        {
        }
    }
}
