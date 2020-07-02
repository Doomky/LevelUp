using System;

namespace LevelUpDTO
{
    public class ChangeUserInfoDTORequest : DTORequest
    {
        public string NewFirstname { get; set; }
        public string NewLastname { get; set; }
        public string NewEmail { get; set; }
        public byte? NewWeightKg { get; set; }

        public ChangeUserInfoDTORequest() : base(Method.POST)
        {
        }
    }
}
