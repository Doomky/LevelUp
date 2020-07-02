using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class ClientCredentialsDTORequest
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
