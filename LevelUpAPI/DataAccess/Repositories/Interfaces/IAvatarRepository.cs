using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IAvatarRepository : IRepository<Avatars, Avatar>
    {
        public Task<Dbo.Avatar> Create();
    }
}
