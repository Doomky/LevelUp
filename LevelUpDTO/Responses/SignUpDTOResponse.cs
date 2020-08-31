using System;

namespace LevelUpDTO
{
    public class SignUpDTOResponse : DTOResponse
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool? Gender { get; set; }
        public byte WeightKg { get; set; }
        public string Email { get; set; }
        public int AvatarId { get; set; }
        public int AvatarLevel { get; set; }
        public int AvatarXp { get; set; }
        public int AvatarXpMax { get; set; }
        public int AvatarSize { get; set; }
        public DateTime CreationDate { get; set; }

        public SignUpDTOResponse()
        {

        }

        public SignUpDTOResponse(
            int id,
            string login,
            string firstname,
            string lastname,
            bool? gender,
            byte weightKg,
            string email,
            int avatarId,
            int avatarLevel,
            int avatarXp,
            int avatarXpMax,
            int avatarSize,
            DateTime creationDate)
        {
            Id = id;
            Login = login;
            Firstname = firstname;
            Lastname = lastname;
            Gender = gender;
            WeightKg = weightKg;
            Email = email;
            AvatarId = avatarId;
            AvatarLevel = avatarLevel;
            AvatarXp = avatarXp;
            AvatarXpMax = avatarXpMax;
            AvatarSize = avatarSize;
            CreationDate = creationDate;
        }
    }
}
