using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class QuestionRepositoryImp : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
