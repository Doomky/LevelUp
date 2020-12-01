using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class AvatarRepository : Repository<Avatars, Avatar>, IAvatarRepository
    {
        public AvatarRepository(levelupContext context, ILogger<AvatarRepository> logger, IMapper mapper) : base(context, context.Avatars, logger, mapper)
        {
        }

        public async Task<Avatar> Create(int skinId)
        {
            Avatar avatar = new Avatar()
            {
                Level = 1,          // Default level, starts at 1
                Size = 1,           // Default size (0 = skinny, 1 = normal, 2 = curvy)
                Xp = 0,             // Default experience, starts at 0
                XpMax = 10,         // Max experience for the actual level
                SkinId = skinId
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

        public async Task<Avatar> AddXp(User user, Quest quest)
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

        public async Task<Avatar> AddXp(User user, int xp)
        {
            var avatar = GetByUser(user).GetAwaiter().GetResult();
            if (avatar != null)
            {
                avatar.Xp += xp;
                while (avatar.Xp >= avatar.XpMax)
                {
                    avatar.Level++;
                    avatar.Xp = 0;
                    avatar.XpMax *= 2;
                }
                avatar = Update(avatar).GetAwaiter().GetResult();
            }
            return avatar;
        }
    }
}
