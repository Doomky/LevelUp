using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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

        public async Task<Avatar> GetByUser(User user)
        {
            try
            {
                var avatar = await (from avatars in _context.Avatars.AsNoTracking()
                       where avatars.Id == user.AvatarId
                       select avatars).FirstOrDefaultAsync();
                return _mapper.Map<Avatar>(avatar);
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get this entry", ex);
                return null;
            }
        }

        public async Task<Dbo.Avatar> AddXp(User user, Quest quest)
        {
            var avatar = GetByUser(user).GetAwaiter().GetResult();
            if (avatar != null)
            {
                if (quest.XpValue.HasValue)
                {
                    avatar.Xp += quest.XpValue.Value;
                    while (avatar.Xp >= avatar.XpMax)
                    {
                        avatar.Level++;
                        avatar.Xp = 0;
                        avatar.XpMax *= 2;
                    }
                    avatar = Update(avatar).GetAwaiter().GetResult();
                }
            }
            return avatar;
        }
    }
}
