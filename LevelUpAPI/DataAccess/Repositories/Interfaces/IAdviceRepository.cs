using LevelUpAPI.Dbo;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public interface IAdviceRepository
    {
        public Task<Dbo.Advice> GetByCategoryForUser(Dbo.Category category, User user);
        public Task<Advice[]> GetAllByCategoryForUser(Dbo.Category category, User user);
        public Task<Dbo.Advice> GetForUser(User user);
    }
}