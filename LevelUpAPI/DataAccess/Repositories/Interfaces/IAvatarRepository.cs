using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IAvatarRepository : IRepository<Avatars, Avatar>
    {
        public Task<Avatar> Create();
        public Task<Avatar> GetByUser(User user);
        public Task<Avatar> AddXp(User user, Quest quest);
    }
}
