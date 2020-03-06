using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Dbo
{
    public interface IObjectWithId
    {
        int Id { get; set; }
    }
}
