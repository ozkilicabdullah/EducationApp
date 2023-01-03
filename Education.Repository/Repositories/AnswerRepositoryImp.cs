using Education.Core.Models;
using Education.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Education.Repository.Repositories
{
    public class AnswerRepositoryImp : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepositoryImp(EducationDbContext context) : base(context)
        {
        }

        public async Task<List<Answer>> GetQuestionAnswers(int questionId)
        {
            List<Answer> answerList = new();
            var query = (from a in _context.Answers
                         join q in _context.Questions on a.QuestionId equals q.Id
                         select a);
            answerList = await query.ToListAsync();
            return answerList;
        }
    }
}
