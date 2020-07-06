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

        public int Level { get; set; }

        public int Xp { get; set; }
        public int XpMax { get; set; }
        public int Size { get; set; }

        public UserInfoDTOResponse(string login,
            string firstname,
            string lastname,
            string gender,
            byte weightKg,
            string email,
            DateTime? lastLoginDate,
            bool googleLinked,
            int level,
            int xp,
            int xpMax,
            int size)
        {
            Login = login;
            Firstname = firstname;
            Lastname = lastname;
            Gender = gender;
            WeightKg = weightKg;
            Email = email;
            LastLoginDate = lastLoginDate;
            GoogleLinked = googleLinked;
            Level = level;
            Xp = xp;
            XpMax = xpMax;
            Size = size;
        }
    }
}
