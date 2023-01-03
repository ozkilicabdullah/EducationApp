using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class EducationContentQuestionRepositoryImp : GenericRepository<EducationContentQuestion>, IEducationContentQuestionsRepository
    {
        public EducationContentQuestionRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
