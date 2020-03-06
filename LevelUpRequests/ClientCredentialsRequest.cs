using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class ClientCredentialsRequest
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
