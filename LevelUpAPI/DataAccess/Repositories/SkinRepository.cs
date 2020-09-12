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
    public class SkinRepository : Repository<Skins, Skin>, ISkinRepository
    {
        public SkinRepository(levelupContext context, ILogger<SkinRepository> logger, IMapper mapper) : base(context, context.Skins, logger, mapper)
        {
        }

        public async Task<IEnumerable<Skin>> GetAll()
        {
            try
            {
                var skinList = (from skins in _context.Skins.AsNoTracking()
                                   select skins).ToList();
                return _mapper.Map<IEnumerable<Skin>>(skinList);
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get the skin list", ex);
                return null;
            }
        }

        public async Task<IEnumerable<Skin>> GetEquipable(bool? gender, int level)
        {
            try
            {
                string genderStr = gender == false ? "man" : (gender == true ? "woman" : "non-binary");
                var skinList = (from skins in _context.Skins.AsNoTracking()
                                where skins.Name.StartsWith(genderStr)
                                where level >= skins.LevelMin 
                                select skins).ToList();
                return _mapper.Map<IEnumerable<Skin>>(skinList);
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get the equipable skin list", ex);
                return null;
            }
        }

        public async Task<Skin> GetByUser(User user)
        {
            try
            {
                var avatar = await (from avatars in _context.Avatars.AsNoTracking()
                                    where avatars.Id == user.AvatarId
                                    select avatars).FirstOrDefaultAsync();
                var skin = await (from skins in _context.Skins.AsNoTracking()
                                    where skins.Id == avatar.SkinId
                                    select skins).FirstOrDefaultAsync();
                return _mapper.Map<Skin>(skin);
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get this entry", ex);
                return null;
            }
        }
    }
}
