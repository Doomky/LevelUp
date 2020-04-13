using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class PasswordRecoveryDataRepository : Repository<PasswordRecoveryDatas, PasswordRecoveryData>, IPasswordRecoveryDataRepository
    {
        public PasswordRecoveryDataRepository(levelupContext context, ILogger<PasswordRecoveryDataRepository> logger, IMapper mapper) : base(context, context.PasswordRecoveryDatas, logger, mapper)
        {

        }

        public async Task<PasswordRecoveryData> GetByHash(string hash)
        {
           var passwordRecoveryDatas = await base.Get();
           return passwordRecoveryDatas
                    .Where((data) => data.Hash == hash)
                    .FirstOrDefault();
        }
    }
}
