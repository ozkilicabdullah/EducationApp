using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class ExamRepositoryImp : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
