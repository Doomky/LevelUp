using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IPasswordRecoveryDataRepository : IRepository<PasswordRecoveryDatas, PasswordRecoveryData>
    {
        public Task<PasswordRecoveryData> GetByHash(string hash); 
    }
}
