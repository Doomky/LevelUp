using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Dbo
{
    public class PasswordRecoveryData : IObjectWithId
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Hash { get; set; }
        public DateTime Date { get; set; }
    }

}
