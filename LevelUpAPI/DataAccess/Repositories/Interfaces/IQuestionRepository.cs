using LevelUpAPI.Dbo;
using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories.Interfaces
{
    public interface IQuestionRepository : IRepository<Questions, Question>
    {
        public Task<IEnumerable<Question>> Get10();
    }
}
