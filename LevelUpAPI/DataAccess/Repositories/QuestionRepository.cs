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
using System.Linq;

namespace LevelUpAPI.DataAccess.Repositories
{
    public class QuestionRepository : Repository<Questions, Question>, IQuestionRepository
    {
        public QuestionRepository(levelupContext context, ILogger<QuestionRepository> logger, IMapper mapper) : base(context, context.Questions, logger, mapper)
        {
        }

        public async Task<IEnumerable<Question>> Get10()
        {
            Random rng = new Random();

            List<Question> questions = (await base.Get()).ToList();
            List<Question> selectedQuestions = new List<Question>();

            for (int i = 0; i < 10; i++)
            {
                int selectedIndex = rng.Next(0, questions.Count);
                Question question = questions[selectedIndex];
                questions.RemoveAt(selectedIndex);
                selectedQuestions.Add(question);
            }

            return selectedQuestions;
        }
    }
}
