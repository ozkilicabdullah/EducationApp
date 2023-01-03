using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class ExamQuestionRespositoryImp : GenericRepository<ExamQuestion>, IExamQuestionsRepository
    {
        public ExamQuestionRespositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
