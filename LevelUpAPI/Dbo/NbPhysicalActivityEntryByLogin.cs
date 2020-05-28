using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Dbo
{
    public class NbPhysicalActivityEntryByLogin
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public int? Total { get; set; }
    }
}
