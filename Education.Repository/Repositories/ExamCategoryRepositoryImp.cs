using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class ExamCategoryRepositoryImp : GenericRepository<ExamCategory>, IExamCategoryRepository
    {
        public ExamCategoryRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
