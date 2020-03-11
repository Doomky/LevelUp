using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class AvatarRepository : Repository<Model.Avatars, Dbo.Avatar>, IAvatarRepository
    {
        public AvatarRepository(levelupContext context, ILogger<AvatarRepository> logger, IMapper mapper) : base(context, context.Avatars, logger, mapper)
        {
        }

        public async Task<Dbo.Avatar> Create()
        {
            Dbo.Avatar avatar = new Dbo.Avatar()
            {
                Level = 1,
                Size = 1,
                Xp = 0,
                XpMax = 10
            };
            return await base.Insert(avatar);
        }
    }
}
