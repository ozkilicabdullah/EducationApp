using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class QuestionCategoryRepositoryImp : GenericRepository<QuestionCategory>, IQuestionCategoryRepository
    {
        public QuestionCategoryRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
