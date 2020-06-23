using AutoMapper;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class QuestRepository : Repository<Model.Quests, Quest>, IQuestRepository
    {
        public QuestRepository(levelupContext context, ILogger<QuestRepository> logger, IMapper mapper) : base(context, context.Quests, logger, mapper)
        {

        }

        public async Task<IEnumerable<Quest>> Get(User user, IQuestTypeRepository questTypeRepository, QuestState? questState)
        {
            var getAll = await base.Get();
            return getAll
                .Where(quest => {
                    var questHandler =  QuestHandlers.QuestHandlers.Create(quest, questTypeRepository);
                    return quest.UserId == user.Id && 
                           questHandler != null && (!questState.HasValue || questState.Value == questHandler.GetState());
                });
        }

        public async Task<IEnumerable<Quest>> Get(User user, int categoryId, IQuestTypeRepository questTypeRepository, QuestState? questState)
        {
            var getAll = await base.Get();
            return getAll
                .Where(quest => {
                    var questHandler = QuestHandlers.QuestHandlers.Create(quest, questTypeRepository);
                    return 
                    quest.UserId == user.Id &&
                    quest.TypeId == categoryId &&
                    questHandler != null && (!questState.HasValue || questState.Value == questHandler.GetState());
            });
        }


        public async Task<Quest> GetById(User user, int questId)
        {
            var getAll = await base.Get();
            return getAll
                .Where(quest => quest.UserId == user.Id && quest.Id == questId)
                .FirstOrDefault();
        }
    }
}
