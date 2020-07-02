using System;

namespace LevelUpDTO
{
    public class ForgotPasswordDTORequest : DTORequest
    {
        public string Login { get; set; }
        public string EmailAddress { get; set; }
        public ForgotPasswordDTORequest() : base(Method.POST)
        {
        }
    }
}
