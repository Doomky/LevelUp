using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface ISkinRepository : IRepository<Skins, Skin>
    {
        Task<IEnumerable<Skin>> GetAll(bool? gender);
        Task<IEnumerable<Skin>> GetEquipable(bool? gender, int level);
        Task<Skin> GetByUser(User user);
    }
}
