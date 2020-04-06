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
    public class QuestTypeRepository : Repository<QuestsTypes, Dbo.QuestType>, IQuestTypeRepository
    {
        public QuestTypeRepository(levelupContext context, ILogger<QuestTypeRepository> logger, IMapper mapper) : base(context, context.QuestsTypes, logger, mapper)
        {
        }

        public async Task<Dbo.QuestType.QuestTypeAsEmum> GetAsEmum(int id)
        {
            Dbo.QuestType questType = (await base.Get(id)).FirstOrDefault();
            if (questType != null)
                return DataAccess.QuestType.AsEnum(questType);
            return Dbo.QuestType.QuestTypeAsEmum.Undefined;
        }
    }
}
