using System;

namespace LevelUpDTO
{
    public class UserInfoDTOResponse : DTOResponse
    {
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public byte WeightKg { get; set; }
        public string Email { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool GoogleLinked { get; set; }

        public UserInfoDTOResponse()
        {

        }

        public UserInfoDTOResponse(string login,
            string firstname,
            string lastname,
            string gender,
            byte weightKg,
            string email,
            DateTime? lastLoginDate,
            bool googleLinked)
        {
            Login = login;
            Firstname = firstname;
            Lastname = lastname;
            Gender = gender;
            WeightKg = weightKg;
            Email = email;
            LastLoginDate = lastLoginDate;
            GoogleLinked = googleLinked;
        }
    }
}
