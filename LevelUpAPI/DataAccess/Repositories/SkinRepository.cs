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

        public async Task<IEnumerable<Skin>> GetAll(bool? gender)
        {
            try
            {
                string genderStr = gender == true ? "man" : (gender == false ? "woman" : "non-binary");
                var skinList = (from skins in _context.Skins.AsNoTracking()
                                   where skins.Name.Contains(genderStr)
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
                string genderStr = gender == true ? "man" : (gender == false ? "woman" : "non-binary");
                var skinList = (from skins in _context.Skins.AsNoTracking()
                                where skins.Name.Contains(genderStr)
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
    }
}
