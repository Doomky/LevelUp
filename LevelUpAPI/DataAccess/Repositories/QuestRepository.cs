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
    public class QuestRepository : Repository<Model.Quests, Quest>, IQuestRepository
    {
        public QuestRepository(levelupContext context, ILogger<QuestRepository> logger, IMapper mapper) : base(context, context.Quests, logger, mapper)
        {

        }

        public async Task<IEnumerable<Quest>> Get(User user)
        {
            var getAll = await base.Get();
            return getAll.Where(quest => quest.UserId == user.Id);
        }

        public async Task<IEnumerable<Quest>> Get(User user, int categoryId)
        {
            var getAll = await base.Get();
            return getAll
                .Where(quest => quest.UserId == user.Id && quest.CategoryId == categoryId);
        }
    }
}
