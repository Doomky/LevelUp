using AutoMapper;
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
    public class AdviceRepository : Repository<Model.Advices, Dbo.Advice>, IAdviceRepository
    {
        public AdviceRepository(levelupContext context, ILogger<AvatarRepository> logger, IMapper mapper) : base(context, context.Advices, logger, mapper)
        {
        }

        public async Task<Advice[]> GetAllByCategoryForUser(Dbo.Category category, User user)
        {
            try
            {
                var categoryAdvices = await (from advice in _context.Advices.AsNoTracking()
                                    where advice.CategoryId == category.Id
                                    select advice).ToArrayAsync();
                return _mapper.Map<Advice[]>(categoryAdvices);
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get this entry", ex);
                return null;
            }
        }

        public async Task<Advice> GetByCategoryForUser(Dbo.Category category, User user)
        {
            try
            {
                var categoryAdvices = await (from advice in _context.Advices.AsNoTracking()
                                             where advice.CategoryId == category.Id
                                             select advice).ToArrayAsync();
                Random random = new Random();
                int selectedAdviceIndex = random.Next(0, categoryAdvices.Length);
                var selectedAdvice = categoryAdvices[selectedAdviceIndex];
                return _mapper.Map<Advice>(selectedAdvice);
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get this entry", ex);
                return null;
            }
        }

        public async Task<Advice> GetForUser(User user)
        {
            try
            {
                var advices = await (from advice in _context.Advices.AsNoTracking()
                                            select advice).ToArrayAsync();
                Random random = new Random();
                int selectedAdviceIndex = random.Next(0, advices.Length);
                var selectedAdvice = advices[selectedAdviceIndex];
                return _mapper.Map<Advice>(selectedAdvice);
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get this entry", ex);
                return null;
            }
        }
    }
}
